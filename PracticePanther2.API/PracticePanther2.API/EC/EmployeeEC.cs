using PracticePanther.Library.Models;
using PracticePanther2.API.DataBase;
using PracticePanther.Library.DTO;

namespace PracticePanther2.API.EC
{
    public class EmployeeEC
    {
        public EmployeeDTO AddOrUpdate(EmployeeDTO dto) 
        {
            //if (dto.Id > 0)
            //{
            //    var employeeToUpdate
            //        = Filebase.Current.Employees
            //        .FirstOrDefault(e => e.Id == dto.Id);
            //    if(employeeToUpdate != null){
            //        Filebase.Current.Employees.Remove(employeeToUpdate);
            //    }
            //    Filebase.Current.Employees.Add(new Employee (dto));
            //}
            //else
            //{
            //    Filebase.Current.Employees.Add(new Employee(dto));
            //}
            Filebase.Current.AddOrUpdate(new Employee(dto));

            return dto;
        }

        public EmployeeDTO? Get(int id)
        {
            var returnVal = FakeDataBase.Employees
                .FirstOrDefault(e => e.Id == id)
                ?? new Employee();

            return new EmployeeDTO(returnVal);

        }

        public EmployeeDTO? Delete(int id)
        {
            var employeeToDelete = FakeDataBase.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                FakeDataBase.Employees.Remove(employeeToDelete);
            }
            return employeeToDelete != null ?
                new EmployeeDTO(employeeToDelete)
                : null;
        }
        public IEnumerable<EmployeeDTO> Search(string query = "")
        {
            return Filebase.Current.Employees.
                Where(e => e.Name.ToUpper()
                    .Contains(query.ToUpper()))
                .Take(1000).Select(e => new EmployeeDTO(e));
        }
    }
}
