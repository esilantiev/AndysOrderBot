using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonBot.Dal.Common;
using HackatonBot.Dal.Entity.Food;

namespace HackatonBot.Dal.Repository.Food
{
    public class FoodOrderRepository : Repository<FoodOrder>
    {
        public FoodOrder FindPendingOrder()
        {
            return _session.QueryOver<FoodOrder>()
                .Where(x => x.OrderStatus == OrderStatus.New)
                .OrderBy(x => x.Id).Asc.Take(1).SingleOrDefault();
        }
    }
}
