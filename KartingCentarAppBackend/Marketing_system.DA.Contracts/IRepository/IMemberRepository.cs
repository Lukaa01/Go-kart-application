using Marketing_system.DA.Contracts.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.DA.Contracts.IRepository
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<Member> GetByEmailAsync(string email);
        Task<Member> GetMemberWithTrainingsEager(int id);
        Task<Member> GetMemberByIdAsync(int id);
        Task<List<Member>> GetMembersForInstructorEager(int id);
        Task<List<Member>> GetAllMembersEager();
    }
}
