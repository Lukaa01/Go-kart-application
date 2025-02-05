using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;

namespace Marketing_system.DA.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public ClientRepository(DataContext context) : base(context)
        {

        }

        public async Task<Client> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<Client>().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
