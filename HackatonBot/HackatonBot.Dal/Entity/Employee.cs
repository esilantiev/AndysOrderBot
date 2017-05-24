using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonBot.Dal.Entity
{
    public class Employee :Entity
    {
        public virtual string Name { get; protected set; }
        public virtual string Surname { get; protected set; }
        public virtual bool Status { get; protected set; }

        public Employee(string name, string surname, bool status)
        {
            Name = name;
            Surname = surname;
            Status = status;
        }

        protected Employee()
        {
        }
    }
}
