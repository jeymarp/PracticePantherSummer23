﻿using PracticePanther.CLI.Models;
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

        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }

        private List<Employee> employees;
        public static EmployeeService? Current {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }
                return instance;
            }
        }

        private EmployeeService()
        {
            employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Jhon Smith", Rate = 45 }

            };
        }

        public void Delete(int id)
        {
            var employeeToDelete = Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
        }

        public void AddOrUpdate(Employee e)
        {
            if (e.Id == 0)
            {
                //add
                e.Id = LastId + 1;
                Employees.Add(e);
            }

        }

        public Employee? Get(int id)
            => Employees.FirstOrDefault(e => e.Id == id);
        

        public IEnumerable<Employee> Search(string query)
        {
            return Employees
                .Where(e => e.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        private int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;
            }
        }

        // new code for Assignment 3
        public Employee? GetRate(decimal rate)
        {
            return Employees.FirstOrDefault(e => e.Rate == rate);
        }
    }
}
