using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;
using Marketing_system.DA.Contracts.Shared;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace Marketing_system.DA.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public ReservationRepository(DataContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Reservation>> GetAllReservationsEager()
        {
            return await _dbContext.Set<Reservation>()
           .Include(m => m.Appointment)
           .Include(c => c.Client)
           .ToListAsync();
        }
        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _dbContext.Set<Reservation>()
            .Include(r => r.Appointment)
            .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
