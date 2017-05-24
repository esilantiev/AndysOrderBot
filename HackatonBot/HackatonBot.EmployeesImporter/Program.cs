using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonBot.Dal.Entity;
using HackatonBot.Dal.Repository;

namespace HackatonBot.EmployeesImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee("Nicolae", "Rusu", true);
            var repository = new EmployeeRepository();
            repository.SaveOrUpdate(employee);
    }
}
}
