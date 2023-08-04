using Newtonsoft.Json;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Utilities;
using PracticePanther.Library.DTO;

namespace PracticePanther.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        private List<EmployeeDTO> employees;
        public List<EmployeeDTO> Employees
        {
            get
            {
                return employees ?? new List<EmployeeDTO>();
            }
        }

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
            var response = new WebRequestHandler()
                    .Get("/Employee").Result;

           employees = JsonConvert
                .DeserializeObject<List<EmployeeDTO>>(response) ?? new List<EmployeeDTO>();
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler().Delete($"/Employee/Delete/{id}").Result;
            var employeeToDelete = Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
        }

        public void Delete(Employee e)
        {
            Delete(e.Id);
        }

        public void AddOrUpdate(EmployeeDTO e)
        {
            var response = new WebRequestHandler().Post("/Employee/", e).Result;
            var myUpdatedEmployee = JsonConvert.DeserializeObject<EmployeeDTO>(response);
            if(myUpdatedEmployee != null)
            {
                var existingEmployee = employees.FirstOrDefault(e => e.Id == myUpdatedEmployee.Id);
                if(existingEmployee == null)
                {
                    employees.Add(myUpdatedEmployee);
                }
                else
                {
                    var index = employees.IndexOf(existingEmployee);
                    employees.RemoveAt(index);
                    employees.Insert(index, myUpdatedEmployee);
                }
            }
        }

        public EmployeeDTO? Get(int id)
        {
            return Employees.FirstOrDefault(c => c.Id == id);
        }

        public EmployeeDTO? Get(decimal rate)
        {
            return Employees.FirstOrDefault(c => c.Rate == rate);
        }

        public IEnumerable<EmployeeDTO> Search(string query)
        {
            return Employees
                .Where(e => e.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }
    }
}
