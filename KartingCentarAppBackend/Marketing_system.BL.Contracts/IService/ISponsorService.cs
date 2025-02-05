using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface ISponsorService
    {
        Task<bool> CreateSponsor(SponsorDTO sponsor);
        Task<bool> AddFunds(FundDTO fund);
    }
}
