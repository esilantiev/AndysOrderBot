using FluentNHibernate.Mapping;
using HackatonBot.Dal.Entity.Food;

namespace HackatonBot.Dal.Map
{
    public class FoodOrderLineMap : EntityMap<FoodOrderLine>
    {
        public FoodOrderLineMap()
        {
            Map(x => x.UserName).Not.Nullable();
            References(x => x.Pizza).Not.Nullable();
            Map(x => x.Quantity).Not.Nullable();
        }
    }
}
