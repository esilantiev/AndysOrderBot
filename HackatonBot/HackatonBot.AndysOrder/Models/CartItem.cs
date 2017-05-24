namespace HackatonBot.AndysOrder.Models
{
    public class CartItem
    {
        public long id { get; set; }
        public long topp { get; set; }
        public long souce { get; set; }
        public long korj { get; set; }
        public long quan { get; set; }

        public CartItem(long id, long topp, long souce, long korj, long quan)
        {
            this.id = id;
            this.topp = topp;
            this.souce = souce;
            this.korj = korj;
            this.quan = quan;
        }
        protected CartItem() { }
    }
}
