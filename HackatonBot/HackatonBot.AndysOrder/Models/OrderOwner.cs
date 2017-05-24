using System;

namespace HackatonBot.AndysOrder.Models
{
    public class OrderOwner
    {
        public string name { get; set; }
        public long city { get; set; } = 2;
        public string street { get; set; }
        public long streetnumber { get; set; } = 1;
        public string house { get; set; }
        public long apt { get; set; }
        public long scara { get; set; }
        public long floor { get; set; }
        public string code { get; set; }
        public string phone { get; set; }
        public string orderInfoDiscountCard { get; set; }
        public string mail { get; set; }
        public string comment { get; set; }
        public string radio_fm { get; set; } = "on";

        public OrderOwner(string name, string street, string house, string phone,  string comment)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException($"{nameof(name)} is null");
            if (string.IsNullOrWhiteSpace(street))
                this.street = "Mitropolit  Varlaam";
            if (string.IsNullOrWhiteSpace(house))
                this.house = "63/23";
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException($"{nameof(phone)} is null");
            if (string.IsNullOrWhiteSpace(comment))
                this.comment = @"cladirea Forum, achitarea cu bonuri corporative";

            this.name = name;
            this.street = street;
            this.house = house;
            this.phone = phone;
            this.comment = comment;
        }
    }
}
