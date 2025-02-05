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
    public class SuccessService : ISuccessService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public SuccessService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSuccess(SuccessDTO success)
        {
            await _unitOfWork.GetSuccessRepository().Add(new Success(success.Place, success.Time, success.Compete_id));
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> AddSuccess(int memberId, int competitionId, List<SuccessDTO> success)
        {
            if(success != null)
            {
                foreach(SuccessDTO item in success)
                {
                    var participate = await _unitOfWork.GetParticipateRepository().Add(new Participate(memberId, competitionId));
                    await _unitOfWork.Save();

                    await _unitOfWork.GetSuccessRepository().Add(new Success(item.Place, item.Time, participate.Entity.Id));
                    await _unitOfWork.Save();
                }
            }
            return true;
        }
    }
}
