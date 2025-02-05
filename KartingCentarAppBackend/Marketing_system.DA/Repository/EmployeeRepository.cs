using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace Marketing_system.DA.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public EmployeeRepository(DataContext context) : base(context)
        {

        }
        public async Task<Employee> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<Employee>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<Employee> GetTrainingsForInstructorEager(int instructorId)
        {
            return _dbContext.Set<Employee>()
               .Where(m => m.Id == instructorId)
               .Include(m => m.Trainings)
               .ThenInclude(t => t.Appointment)
               .FirstOrDefaultAsync();
        }
    }
}
