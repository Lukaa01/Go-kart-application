using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IDebtService
    {
        Task<bool> CreateDebt(DebtDTO debt);

        Task<IEnumerable<DebtDTO>> GetDebtsByMemberId(int id);
        Task<bool> UpdateDebt(DebtDTO debt);
    }
}
