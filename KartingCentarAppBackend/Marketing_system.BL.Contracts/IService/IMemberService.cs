using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IMemberService
    {
        Task<MemberDTO> CreateMember(MemberDTO member);
        Task<bool> BlockMember(MemberDTO member);
        Task<MemberDTO> GetMemberById(int id);
        Task<List<MemberDTO>> GetAllMembers();
        Task<List<MemberDTO>> GetMembersForInstructor(int id);
        Task<MemberDTO> UpdateMember(MemberDTO member);
    }
}
