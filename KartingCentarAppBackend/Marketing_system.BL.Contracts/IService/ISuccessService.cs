using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface ISuccessService
    {
        Task<bool> CreateSuccess(SuccessDTO success);
        Task<bool> AddSuccess(int memberId, int competitionId, List<SuccessDTO> success);
    }
}
