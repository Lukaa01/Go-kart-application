using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts.IRepository;

namespace Marketing_system.DA.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();
        public IVoziloRepository GetVoziloRepository();
        public ICartServiceRepository GetCartServiceRepository();
        public IMemberRepository GetMemberRepository();
        public IDebtRepository GetDebtRepository();
        public IAppointmentRepository GetAppointmentRepository();
        public IReservationRepository GetReservationRepository();
        public IClientRepository GetClientRepository();
        public IVoucherRepository GetVoucherRepository();
        public IPriceListRepository GetPriceListItemRepository();
        public IEmployeeRepository GetEmployeeRepository();
        public ITrainingRepository GetTrainingRepository();
        public IFinancialTransactionRepository GetFinancialTransactionRepository();
        public IPartRequestRepository GetPartRequestRepository();
        public IPartRepository GetPartRepository();
        public IPartItemRepository GetPartItemRepository();
        public IParticipateRepository GetParticipateRepository();
        public ICompetitionRepository GetCompetitionRepository();
        public ISuccessRepository GetSuccessRepository();
        public ISponsorRepository GetSponsorRepository();
        public IFundRepository GetFundRepository();
        public ITransactionRequestRepository GetTransactionRequestRepository();
        public ITransactionMembershipRepository GetTransactionMembershipRepository();
        public ITransactionReservationRepository GetTransactionReservationRepository();
        public ITransactionFundRepository GetTransactionFundRepository();
        public ITokenGeneratorRepository GetTokenRepository();

    }
}
