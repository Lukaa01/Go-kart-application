using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;
using Marketing_system.DA.Contracts.Shared;
using Microsoft.EntityFrameworkCore;

namespace Marketing_system.DA.Repository
{
    public class PartRequestRepository : Repository<PartRequest>, IPartRequestRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public PartRequestRepository(DataContext context) : base(context)
        {

        }
        public async Task<List<PartRequest>> GetAllEager()
        {
            return await _dbContext.Set<PartRequest>().Include(x => x.Part).ToListAsync();
        }
    }
}
