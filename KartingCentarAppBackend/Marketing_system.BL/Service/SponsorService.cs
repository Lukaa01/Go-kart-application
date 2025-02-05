using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;

namespace Marketing_system.BL.Service
{
    public class SponsorService : ISponsorService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public SponsorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSponsor(SponsorDTO sponsor)
        {
            await _unitOfWork.GetSponsorRepository().Add(new Sponsor(sponsor.Name));
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> AddFunds(FundDTO fund)
        {
            await _unitOfWork.GetFundRepository().Add(new Fund(fund.Amount, fund.Sponsor_id));
            await _unitOfWork.Save();
            return true;
        }
    }
}
