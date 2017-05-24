using System;

namespace HackatonBot.Dal.Entity.Food
{
    public class FoodOrderLine : Entity
    {
        public virtual string UserName { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual int Quantity { get; set; }

        public FoodOrderLine(string user, Pizza pizza, int quantity)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentNullException($"{nameof(user)} is null");
            if (pizza == null)
                throw new ArgumentNullException($"{nameof(pizza)} is null");

            UserName = user;
            Pizza = pizza;
            Quantity = quantity;
        }
        protected FoodOrderLine() { }
    }
}
