using System;
using System.Collections.Generic;
using System.Linq;
using HackatonBot.AndysOrder.Models;
using HackatonBot.Dal.Entity.Food;

namespace HackatonBot.AndysOrder.Helpers
{
    public class ConvertToAndysFormat
    {
        public static IList<CartItem> Convert(FoodOrder foodOrder)
        {
            var tuples = foodOrder.FoodOrderLines.Select(x => new { x.Pizza.ExternalId, x.Quantity });
            var cartItems = tuples.GroupBy(x => x.ExternalId).Select(x =>
                    new CartItem(long.Parse(x.Key), 0, 0, 0, x.Sum(y => y.Quantity))).ToList();

            return cartItems;
        }

        public static OrderOwner GetOrderOwner(FoodOrder foodOrder)
        {
            var orderOwner = new OrderOwner(foodOrder.OwnerName, foodOrder.Street, foodOrder.HouseNumber,
                foodOrder.ContactNumber, string.Empty);
            return orderOwner;
        }
    }
}