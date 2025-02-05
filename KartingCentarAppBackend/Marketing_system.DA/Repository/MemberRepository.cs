using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public MemberRepository(DataContext context) : base(context)
        {

        }
        public async Task<Member> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<Member>().FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<Member> GetMemberWithTrainingsEager(int id)
        {
            return await _dbContext.Set<Member>()
            .Where(m => m.Id == id)
            .Include(m => m.Trainings)
            .ThenInclude(t => t.Appointment)
            .FirstOrDefaultAsync();
        }
        public async Task<List<Member>> GetMembersForInstructorEager(int id)
        {
            return await _dbContext.Set<Member>()
            .Where(m => m.Instruktor_id == id)
            .Include(m => m.Category)
            .ToListAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _dbContext.Set<Member>()
            .Where(m => m.Id == id)
            .Include(m => m.Category)
            .FirstOrDefaultAsync();
        }
        public async Task<List<Member>> GetAllMembersEager()
        {
            return await _dbContext.Set<Member>()
           .Include(m => m.Category)
           .ToListAsync();
        }
    }
}
