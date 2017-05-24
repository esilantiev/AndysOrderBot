using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HackatonBot.AndysOrder.Helpers;
using HackatonBot.AndysOrder.Infrastructure;
using HackatonBot.AndysOrder.Models;
using HackatonBot.Dal.Common;
using HackatonBot.Dal.Entity;
using HackatonBot.Dal.Entity.Food;
using HackatonBot.Dal.Repository;
using HackatonBot.Dal.Repository.Food;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using Microsoft.Bot.Connector;

namespace HackatonBot.AndysOrder.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        [Serializable]
        public class ConfirmPizzaDialog : IDialog<object>
        {
            public Task StartAsync(IDialogContext context)
            {
                context.Wait(ConfirmPizza);
                //PromptDialog.Confirm(context, PizzaConfirmed, "Are you sure?");
                return Task.FromResult<object>(null);
            }

            private Task ConfirmPizza(IDialogContext context, IAwaitable<IMessageActivity> result)
            {
                //var m = await result;
                PromptDialog.Confirm(context, PizzaConfirmed, "Are you sure?");
                //context.Wait(ConfirmPizza);
                return Task.FromResult<object>(null);
            }

            private async Task PizzaConfirmed(IDialogContext context, IAwaitable<bool> result)
            {
                var yn = await result;
                context.Done(yn);
                //await context.PostAsync("Thank you for: " + yn);
            }
        }

        //[Serializable]
        //public class PizzaOrder
        //{
        //    public List<string> Pizza;

        //    public static IForm<PizzaOrder> BuildForm()
        //    {
        //        OnCompletionAsyncDelegate<PizzaOrder> processOrder = async (context, state) =>
        //        {
        //            foreach (var pizza in state.Pizza)
        //            {
        //                //var orderLine = new FoodOrderLine(contex);
        //            }
        //            await context.PostAsync("We are ordered your pizza.");
        //        };

        //        return new FormBuilder<PizzaOrder>()
        //                    .Message("Welcome to the pizza order bot!")
        //                    .Field(new FieldReflector<PizzaOrder>(nameof(Pizza))
        //                    .SetType(null)
        //                    .SetActive((state) => true)
        //                    .SetDefine( (state, field) =>
        //                        {
        //                            var values = Andys.GetPizzas().ToArray();
        //                            foreach (var pizzaType in values)
        //                            {
        //                                field.AddDescription(pizzaType, pizzaType.Name +" "+ pizzaType.Price+" MDL");
        //                            }
        //                            return Task.FromResult(true);
        //                        }
        //                        )
        //                    )
        //                    .Confirm("{Pizza} ???")
        //                    .AddRemainingFields()
        //                    .Message("Thanks for ordering a pizza!")
        //                    .OnCompletion(processOrder)
        //                    .Build();
        //    }
        //};

        //internal static IDialog<PizzaOrder> MakeRootDialog()
        //{
        //    return Chain.From(() => FormDialog.FromForm(PizzaOrder.BuildForm));
        //}

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                //await Conversation.SendAsync(activity, MakeRootDialog);

                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return
                PizzaLuisModel pizzaLuis = await PizzaClient.ParseInputText(activity.Text);
                Pizza pizza = null;
                List<Pizza> allPizza = new List<Pizza>();

                string strResponse = string.Empty;

                switch (pizzaLuis.topScoringIntent.intent)
                {
                    case "GetPizza":
                        pizza = Andys.GetByName(pizzaLuis.entities.First().entity);
                        if (pizza != null) strResponse = $"To order pizza '{pizza.Name}', type 'order {pizza.Name}'";
                        break;
                    case "GetListOfPizza":
                        allPizza = Andys.GetPizzas().ToList();
                        if (allPizza.Any()) strResponse = "Type 'order {pizzaName}', ex. 'order rancho'";
                        break;
                    case "OrderPizza":
                        pizza = Andys.GetByName(pizzaLuis.entities.First().entity);
                        AddOrder(activity, pizza);
                        if (pizza != null) strResponse = $"Your pizza '{pizza.Name}' is added to cart. Thank you!";
                        break;
                    case "ExecuteOrder":
                        var foodOrderRepo = new FoodOrderRepository();
                        var foodOrder = foodOrderRepo.FindPendingOrder();
                        if (foodOrder == null)
                        {
                            strResponse = "Your cart is empty, add some pizza";
                            break;
                        }

                        var cartItems = ConvertToAndysFormat.Convert(foodOrder);
                        var requestHelper = new RequestHelper();
                        var orderOwner = ConvertToAndysFormat.GetOrderOwner(foodOrder);
                        requestHelper.Order(orderOwner, cartItems);
                        foodOrder.OrderStatus = OrderStatus.Closed;
                        foodOrderRepo.SaveOrUpdate(foodOrder);
                        strResponse = "Your order is placed. Wait for a call!"; 
                        break;
                    default:
                        strResponse = "Please specify another pizza name";
                        break;
                }


                var stringResponse = string.Join("\n\n", allPizza
                    .Select((x, index) => index + 1 + ") " + " {" + x.ExternalId + "} " + x.Name + " " + x.Price + " MDL"));

                if (pizza != null)
                {
                    stringResponse = pizza.ExternalId + " " + pizza.Name + " " + pizza.Price + " MDL";
                }
                stringResponse += "\n\n" + strResponse;

                // return our reply to the user
                Activity reply = activity.CreateReply(stringResponse);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                var message = HandleSystemMessage(activity);
                await connector.Conversations.ReplyToActivityAsync(message);

            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private void AddOrder(Activity activity, Pizza pizza)
        {
            var repositoryOrder = new FoodOrderRepository();
            var pizzaRepo = new PizzaRepository();
            var orderLine = new FoodOrderLine(activity.From.Name, pizza, 1);
            var order = repositoryOrder.FindPendingOrder() ??
                new FoodOrder(new List<FoodOrderLine>(), activity.From.Name, "079017134");
            order.FoodOrderLines.Add(orderLine);
            pizzaRepo.SaveOrUpdate(orderLine.Pizza);
            repositoryOrder.SaveOrUpdate(order);
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                return message.CreateReply("AndysPizza bot welcomes you!");
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return message;
        }


    }
}