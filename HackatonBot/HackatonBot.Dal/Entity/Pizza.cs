namespace HackatonBot.Dal.Entity
{
    using System;

    public class Pizza : Entity
    {
        #region Public members

        public virtual string Name { get; protected set; }
        public virtual double Price { get; protected set; }
        public virtual string ExternalId { get; set; }

        public Pizza(string name, double price, string externalId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Name = name;
            Price = price;
            ExternalId = externalId;
        }

        protected Pizza()
        {
        }

        #endregion
    }
}