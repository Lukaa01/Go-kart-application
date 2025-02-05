using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> CreateEmployee(EmployeeDTO employee);
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employee);
        Task<EmployeeDTO> GetEmployeeById(int id);
    }
}
