namespace HackatonBot.BookBot.Controllers
{
   using System;
   using System.Collections.Generic;
   using System.Configuration;
   using System.Linq;
   using System.Net;
   using System.Net.Http;
   using System.Text;
   using System.Threading.Tasks;
   using System.Web.Http;
   using Dal.Entity.Library;
   using Microsoft.Bot.Connector;
   using Newtonsoft.Json;
   using Services;

   [BotAuthentication]
   public class MessagesController : ApiController
   {
      #region Public members

      /// <summary>
      /// POST: api/Messages
      /// Receive a message from a user and reply to it
      /// </summary>
      public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
      {
         if (activity.Type == ActivityTypes.Message)
         {
            var bookService = new BookService();
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            // calculate something for us to return
            string replyString = "";
            BookLuis bookLuis = await ParseUserInput(activity.Text);
            if (bookLuis.topScoringIntent != null)
            {
               switch (bookLuis.topScoringIntent.intent)
               {
                  case "Help":
                     replyString = "I will help you to see the books in Amdaris library and borrow one of it. \n\n";
                     replyString +=
                        "To see the books, please, write something similar to 'find book (topic/name/author)'\n\n";
                     replyString +=
                        "To borrow the books, please, write something similar to 'borrow book (topic/name/author)'";
                     break;
                  case "Take":
                     List<string> filters2 = bookLuis.entities.Select(x => x.entity).ToList();
                     var booksToBorrow = bookService.GetBooks(filters2);
                     if (booksToBorrow.Count > 1)
                     {
                        replyString = "Too many things found. Please specify narrower criteria. \n\n";
                        var sbBorrow = new StringBuilder();
                        var index = 0;
                        foreach (AmdarisBook amdarisBook in booksToBorrow)
                           sbBorrow.AppendLine((++index) + ". " + amdarisBook + "\n");
                        replyString += sbBorrow.ToString();
                     }
                     else if (booksToBorrow.Count < 1)
                     {
                        replyString = "No books found";
                     }
                     else
                     {
                        var bookToBorrow = booksToBorrow.Single();
                        if (bookToBorrow.BookStatus == BookStatus.Read)
                           replyString = $"It is read by {bookToBorrow.ReadBy}. Please negotiate with him.";
                        else
                        {
                           bookToBorrow.Borrow(activity.From.Name);
                           bookService.Update(bookToBorrow);
                           replyString = $"Book successfully borrowed to {activity.From.Name}.";
                        }
                     }
                     break;
                  case "List":
                     List<string> filters = bookLuis.entities.Select(x => x.entity).ToList();

                     IList<AmdarisBook> books = bookService.GetBooks(filters);
                     if (books.Count == 0)
                     {
                        replyString = "No such books found in the library.";
                     }
                     else
                     {
                        var sb = new StringBuilder();
                        var index2 = 0;
                        foreach (AmdarisBook amdarisBook in books)
                           sb.AppendLine((++index2) + ". " + amdarisBook + "\n");
                        replyString = sb.ToString();
                     }
                     break;
                  default:
                     replyString = "Sorry, I do not understand. I shall do better next time.";
                     break;
               }
            }

            // return our reply to the user
            Activity reply = activity.CreateReply(replyString);
            await connector.Conversations.ReplyToActivityAsync(reply);
         }


         else
            HandleSystemMessage(activity);
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
         return response;
      }

      #endregion

      #region Non-public static members

      private static async Task<BookLuis> ParseUserInput(string strInput)
      {
         string strEscaped = Uri.EscapeDataString(strInput);

         using (var client = new HttpClient())
         {
            string uri = ConfigurationManager.AppSettings["LuisUrl"];
            uri = uri + "&q=" + strEscaped;
            HttpResponseMessage msg = await client.GetAsync(uri);

            if (msg.IsSuccessStatusCode)
            {
               string jsonResponse = await msg.Content.ReadAsStringAsync();
               var data = JsonConvert.DeserializeObject<BookLuis>(jsonResponse);
               return data;
            }
            throw new Exception("Exception communicating with Luis.");
         }
      }

      #endregion

      #region Non-public members

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
            // Handle add/remove from contact lists
            // Activity.From + Activity.Action represent what happened
         }
         else if (message.Type == ActivityTypes.Typing)
         {
            // Handle knowing tha the user is typing
         }
         else if (message.Type == ActivityTypes.Ping)
         {
         }

         return null;
      }

      #endregion
   }
}