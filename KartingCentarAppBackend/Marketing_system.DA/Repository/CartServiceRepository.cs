using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Marketing_system.DA.Repository
{
    public class CartServiceRepository : Repository<CartService>, ICartServiceRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public CartServiceRepository(DataContext context) : base(context)
        {

        }

        public Task<IEnumerable<CartService>> GetServicesByVehicleId(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<CartService> GetServiceEager(int id)
        {
            return await _dbContext.Set<CartService>()
            .Include(r => r.PartItems)
            .ThenInclude(p => p.Part)
            .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
