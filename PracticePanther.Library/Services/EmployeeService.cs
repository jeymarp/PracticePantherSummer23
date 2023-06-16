using PracticePanther.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        private static object instanceLock = new object();

        public static EmployeeService Current {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeService();
                    }
                }
                return instance;
            }
        }
        private List<Employee>? employeeList;

        private EmployeeService()
        {
            employeeList = new List<Employee>
            {
                new Employee{Id = 1, Name = "Employee1"},
                new Employee{Id = 2, Name = "Employee2"},
                new Employee{Id = 1, Name = "Employee3"}
            };
        }

        public List<Employee> EmployeeList
        {
            get { return employeeList; }
        }

        public Employee? Get(int id)
        {
            return employeeList.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee? employee)
        {
            if(employee != null)
            {
                employeeList.Add(employee);
            }
        }

        public void Remove(int id)
        {
            var employeeToRemove = Get(id);
            if(employeeToRemove != null)
            {
                employeeList.Remove(employeeToRemove);
            }
        }

        public void Delete(Employee e)
        {
            Remove(e.Id);
        }

        public void Read()
        {
            employeeList.ForEach(Console.WriteLine);
        }

    }
}
