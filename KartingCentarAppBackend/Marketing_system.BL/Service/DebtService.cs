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
    public class DebtService : IDebtService
    {
        public IUnitOfWork _unitOfWork;
        public DebtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateDebt(DebtDTO debt)
        {
            await _unitOfWork.GetDebtRepository().Add(new Debt(debt.Id, debt.Amount, debt.Description, false, debt.Member_id));
            await _unitOfWork.Save();
            return true;
        }
        public async Task<IEnumerable<DebtDTO>> GetDebtsByMemberId(int id)
        {
            var temp = await _unitOfWork.GetDebtRepository().GetAll();
            List<Debt> tempResult = new List<Debt>();
            foreach (Debt d in temp)
            {
                if (d.Member_id == id && d.IsPaid == false)
                {
                    tempResult.Add(d);
                }
            }
            var result = tempResult.Select(debt => new DebtDTO
            {
                Id = debt.Id,
                Amount = debt.Amount,
                Description = debt.Description,
                Member_id = debt.Member_id
            });
            return result;
        }
        public async Task<bool> UpdateDebt(DebtDTO debt)
        {
            _unitOfWork.GetDebtRepository().Update(new Debt(debt.Id, debt.Amount, debt.Description, debt.IsPaid, debt.Member_id));
            await _unitOfWork.Save();
            return true;
        }
    }
}
