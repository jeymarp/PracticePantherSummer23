using PracticePanther2.API.EC;
using PracticePanther.Library.Models;

namespace PracticePanther2.API.DataBase
{
    public static class FakeDataBase
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee{ Id = 1, Name = "Employee 1", Rate = 625},
            new Employee{ Id = 2, Name = "Employee 2", Rate = 635},
            new Employee{ Id = 3, Name = "Employee 3", Rate = 600},
            new Employee{ Id = 4, Name = "Employee 4", Rate = 725}
         };

        public static int LastEmployeeId => Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;

    }
}
