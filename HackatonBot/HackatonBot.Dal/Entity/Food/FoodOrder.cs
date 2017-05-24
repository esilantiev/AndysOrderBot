using System;
using System.Collections.Generic;
using System.Net.Sockets;
using HackatonBot.Dal.Common;

namespace HackatonBot.Dal.Entity.Food
{
    public class FoodOrder : Entity
    {
        public virtual IList<FoodOrderLine> FoodOrderLines { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual string OwnerName { get; set; }
        public virtual string ContactNumber { get; set; }
        public virtual string Street { get; set; }
        public virtual string HouseNumber { get; set; }

        public FoodOrder(IList<FoodOrderLine> foodOrderLines, string ownerName,
            string contactNumber, string street=null, string houseNumber=null)
        {
            if (foodOrderLines == null)
                throw new ArgumentNullException($"{nameof(foodOrderLines)} is null");
            if (contactNumber == null)
                throw new ArgumentNullException($"{nameof(contactNumber)} is null");
            if (ownerName == null)
                throw new ArgumentNullException($"{nameof(ownerName)} is null");

            FoodOrderLines = foodOrderLines;
            OwnerName = ownerName;
            ContactNumber = contactNumber;
            Street = street;
            HouseNumber = houseNumber;
            OrderStatus = OrderStatus.New;
        }
        protected FoodOrder() { }
    }
}
