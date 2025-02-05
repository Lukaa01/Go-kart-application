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
    public class FinancialTransactionService : IFinancialTransactionService
    {
        public IUnitOfWork _unitOfWork;
        public FinancialTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateFinancialTransaction(int id, FinancialTransactionDTO transaction)
        {
            var newTransaction = await _unitOfWork.GetFinancialTransactionRepository().Add(new FinancialTransaction(transaction.Id, transaction.Amount, DateOnly.Parse(transaction.Date), transaction.Description, transaction.Type));
            await _unitOfWork.Save();

            if(transaction.Type == "clanarina")
            {
                await _unitOfWork.GetTransactionMembershipRepository().Add(new TransactionMembership(newTransaction.Entity.Id, id));
                await _unitOfWork.Save();

                var debt = await _unitOfWork.GetDebtRepository().GetByIdAsync(id);

                debt.IsPaid = true;

                _unitOfWork.GetDebtRepository().Update(debt);
                await _unitOfWork.Save();

            } else if (transaction.Type == "ind_trening")
            {
                await _unitOfWork.GetTransactionRequestRepository().Add(new TransactionRequest(newTransaction.Entity.Id, id));
                await _unitOfWork.Save();

                /*var debt = await _unitOfWork.GetPartRequestRepository().GetByIdAsync(id);
                _unitOfWork.GetPartRequestRepository().Update(new Debt(debt.Id, debt.Amount, debt.Description, true, debt.Member_id));
                await _unitOfWork.Save();*/ //KAD BUDES RADIO PRIHVATANJE ZAHTEVA URADI I OVO!!!
            } else if (transaction.Type == "rezervacija")
            {
                await _unitOfWork.GetTransactionReservationRepository().Add(new TransactionReservation(newTransaction.Entity.Id, id));
                await _unitOfWork.Save();
            } else if (transaction.Type == "sponzorstvo")
            {
                await _unitOfWork.GetTransactionFundRepository().Add(new TransactionFund(newTransaction.Entity.Id, id));
                await _unitOfWork.Save();
            }
            return true;
        }

        public async Task<IEnumerable<FinancialTransactionDTO>> GetFinancialTransactions()
        {
            var tempResult = await _unitOfWork.GetFinancialTransactionRepository().GetAll();
            var result = tempResult.Select(transaction => new FinancialTransactionDTO
            {
                Amount = transaction.Amount,
                Date = transaction.Date.ToString("yyyy-MM-dd"),
                Description = transaction.Description,
                Type = transaction.Type
            });
            return result;
        }
    }
}
