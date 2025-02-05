using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Model;

namespace Marketing_system.DA.Contracts.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByEmailAsync(string email);
        Task<Employee> GetTrainingsForInstructorEager(int instructorId);
    }
}
