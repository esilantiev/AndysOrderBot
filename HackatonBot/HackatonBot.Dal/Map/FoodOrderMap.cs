using HackatonBot.Dal.Common;
using HackatonBot.Dal.Entity.Food;

namespace HackatonBot.Dal.Map
{
    public class FoodOrderMap : EntityMap<FoodOrder>
    {
        public FoodOrderMap()
        {
            HasMany(x => x.FoodOrderLines).Cascade.All();
            Map(x => x.OrderStatus).CustomType<OrderStatus>().Not.Nullable();
            Map(x => x.OwnerName).Not.Nullable();
            Map(x => x.ContactNumber).Not.Nullable();
            Map(x => x.Street);
            Map(x => x.HouseNumber);
        }
    }
}
