using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonBot.Dal.Entity;

namespace HackatonBot.Dal.Map
{
    public class EmployeeMap: EntityMap<Employee>
    {
        public EmployeeMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Surname).Not.Nullable();
            Map(x => x.Status).Not.Nullable();
        }
    }
}
