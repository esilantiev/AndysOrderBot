using System;
using System.Collections.Generic;
using System.Net.Http;
using HackatonBot.AndysOrder.Models;
using HackatonBot.Dal.Entity.Food;

namespace HackatonBot.AndysOrder.Helpers
{
    public class RequestHelper
    {
        public void Order(OrderOwner orderOwner, IList<CartItem> dish)
        {
            if (orderOwner == null)
                throw new ArgumentNullException($"{nameof(orderOwner)} is null");
            if (dish == null)
                throw new ArgumentNullException($"{nameof(dish)} is null");
            var client = new HttpClient();
            using (client)
            {
                foreach (var cartItem in dish)
                {
                    AddToCart(client, cartItem);
                }
                OwnerForm(client, orderOwner);

                // this method will sent the order to Andys
                //var submitOrder = SubmitOrder(client);
            }
        }

        private HttpResponseMessage SubmitOrder(HttpClient client)
        {
            var response = client.GetAsync("http://www.andys.md/pages/placeorder/").Result;
            return response;
        }

        private void OwnerForm(HttpClient client, OrderOwner orderOwner)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>(nameof(orderOwner.name), orderOwner.name ),
                    new KeyValuePair<string, string>(nameof(orderOwner.city), orderOwner.city.ToString()),
                    new KeyValuePair<string, string>(nameof(orderOwner.street), orderOwner.street),
                    new KeyValuePair<string, string>(nameof(orderOwner.streetnumber), orderOwner.streetnumber.ToString()),
                    new KeyValuePair<string, string>(nameof(orderOwner.house), orderOwner.house),
                    new KeyValuePair<string, string>(nameof(orderOwner.phone), orderOwner.phone),
                    new KeyValuePair<string, string>(nameof(orderOwner.radio_fm), orderOwner.radio_fm)
                });
            var responce = client.GetAsync("http://www.andys.md/ru/pages/cart/step2/").Result;
            var postResponse = client.PostAsync("http://www.andys.md/pages/setcartadr/", content).Result;
        }

        private void AddToCart(HttpClient client, CartItem dish)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>(nameof(dish.id), dish.id.ToString()),
                new KeyValuePair<string, string>(nameof(dish.topp), dish.topp.ToString()),
                new KeyValuePair<string, string>(nameof(dish.souce), dish.souce.ToString()),
                new KeyValuePair<string, string>(nameof(dish.korj), dish.korj.ToString()),
                new KeyValuePair<string, string>(nameof(dish.quan), dish.quan.ToString())
            });

            var response = client.PostAsync(new Uri("http://www.andys.md/pages/addtocart/"), content).Result;
        }
    }
}