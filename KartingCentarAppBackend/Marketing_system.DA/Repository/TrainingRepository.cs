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
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public TrainingRepository(DataContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await _dbContext.Set<Training>()
                .Include(m => m.Appointment)
                .ToListAsync();
        }

        public async Task<bool> DeleteOrganizuje(int id)
        {
            var trainings1 = await _dbContext.Set<Dictionary<string, object>>("organizuje")
            .Where(e => (int)e["trening_trening_id"] == id)
            .ToListAsync();

            var trainings2 = await _dbContext.Set<Dictionary<string, object>>("posecuje")
            .Where(e => (int)e["trening_trening_id"] == id)
            .ToListAsync();

            if (trainings1.Any())
            {
                _dbContext.RemoveRange(trainings1);
                await _dbContext.SaveChangesAsync();
            }

            if (trainings2.Any())
            {
                _dbContext.RemoveRange(trainings2);
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}
