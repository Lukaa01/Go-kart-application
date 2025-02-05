using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Shared;
using Marketing_system.DA.Repository;

namespace Marketing_system.DA
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context) 
        {
            _context = context;
        }
        public async void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)  
                _context.Dispose();
            _context = null;
        }

        public async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            } catch(Exception ex)
            {
                Console.WriteLine($"Error saving changes to the database: {ex.Message}");
                throw;
            }
        }

        private IVoziloRepository _voziloRepository { get; set; }
        private ICartServiceRepository _serviceRepository { get; set; }
        private IMemberRepository _memberRepository { get; set; }
        private IDebtRepository _debtRepository {  get; set; }
        private IAppointmentRepository _appointmentRepository { get; set; }
        private IReservationRepository _reservationRepository { get; set; }
        private IClientRepository _clientRepository {  get; set; }
        private IVoucherRepository _voucherRepository {  get; set; }
        private IPriceListRepository _priceListRepository {  get; set; }
        private IEmployeeRepository _employeeRepository {  get; set; }
        private ITrainingRepository _trainingRepository {  get; set; }
        private IFinancialTransactionRepository _financialTransactionRepository {  get; set; }
        private IPartRepository _partRepository { get; set; }
        private IPartItemRepository _partItemRepository { get; set; }
        private IPartRequestRepository _partRequestRepository {  get; set; }
        private IParticipateRepository _participateRepository {  get; set; }
        private ICompetitionRepository _competitionRepository {  get; set; }
        private ISuccessRepository _successRepository {  get; set; }
        private ISponsorRepository _sponsorRepository {  get; set; }
        private IFundRepository _fundRepository { get; set; }
        private ITransactionFundRepository _transactionFundRepository {  get; set; }
        private ITransactionReservationRepository _transactionReservationRepository {  get; set; }
        private ITransactionRequestRepository _transactionRequestRepository {  get; set; }
        private ITransactionMembershipRepository _transactionMembershipRepository {  get; set; }
        private ITokenGeneratorRepository _tokenGeneratorRepository { get; set; }

        public IVoziloRepository GetVoziloRepository()
        {
            return _voziloRepository ?? (_voziloRepository = new VoziloRepository(_context));
        }
        public ICartServiceRepository GetCartServiceRepository()
        {
            return _serviceRepository ?? (_serviceRepository = new CartServiceRepository(_context));
        }
        public IMemberRepository GetMemberRepository()
        {
            return _memberRepository ?? (_memberRepository = new MemberRepository(_context));
        }
        public IDebtRepository GetDebtRepository()
        {
            return _debtRepository ?? (_debtRepository = new DebtRepository(_context));
        }
        public IAppointmentRepository GetAppointmentRepository()
        {
            return _appointmentRepository ?? (_appointmentRepository = new AppointmentRepository(_context));
        }
        public IReservationRepository GetReservationRepository()
        {
            return _reservationRepository ?? (_reservationRepository = new ReservationRepository(_context));
        }
        public IClientRepository GetClientRepository()
        {
            return _clientRepository ?? (_clientRepository = new ClientRepository(_context));
        }
        public IVoucherRepository GetVoucherRepository()
        {
            return _voucherRepository ?? (_voucherRepository = new VoucherRepository(_context));
        }
        public IPriceListRepository GetPriceListItemRepository()
        {
            return _priceListRepository ?? (_priceListRepository = new PriceListRepository(_context));
        }
        public IEmployeeRepository GetEmployeeRepository()
        {
            return _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_context));
        }
        public ITrainingRepository GetTrainingRepository()
        {
            return _trainingRepository ?? (_trainingRepository = new TrainingRepository(_context));
        }
        public IFinancialTransactionRepository GetFinancialTransactionRepository()
        {
            return _financialTransactionRepository ?? (_financialTransactionRepository = new FinancialTransactionRepository(_context));
        }
        public IPartRepository GetPartRepository()
        {
            return _partRepository ?? (_partRepository = new PartRepository(_context));
        }
        public IPartItemRepository GetPartItemRepository()
        {
            return _partItemRepository ?? (_partItemRepository = new PartItemRepository(_context));
        }
        public IPartRequestRepository GetPartRequestRepository()
        {
            return _partRequestRepository ?? (_partRequestRepository = new PartRequestRepository(_context));
        }
        public ICompetitionRepository GetCompetitionRepository()
        {
            return _competitionRepository ?? (_competitionRepository = new CompetitionRepository(_context));
        }
        public IParticipateRepository GetParticipateRepository()
        {
            return _participateRepository ?? (_participateRepository = new ParticipateRepository(_context));
        }
        public ISuccessRepository GetSuccessRepository()
        {
            return _successRepository ?? (_successRepository = new SuccessRepository(_context));
        }
        public ISponsorRepository GetSponsorRepository()
        {
            return _sponsorRepository ?? (_sponsorRepository = new SponsorRepository(_context));
        }
        public IFundRepository GetFundRepository()
        {
            return _fundRepository ?? (_fundRepository = new FundRepository(_context));
        }
        public ITransactionFundRepository GetTransactionFundRepository()
        {
            return _transactionFundRepository ?? (_transactionFundRepository = new TransactionFundRepository(_context));
        }
        public ITransactionReservationRepository GetTransactionReservationRepository()
        {
            return _transactionReservationRepository ?? (_transactionReservationRepository = new TransactionReservationRepository(_context));
        }
        public ITransactionRequestRepository GetTransactionRequestRepository()
        {
            return _transactionRequestRepository ?? (_transactionRequestRepository = new TransactionRequestRepository(_context));
        }
        public ITransactionMembershipRepository GetTransactionMembershipRepository()
        {
            return _transactionMembershipRepository ?? (_transactionMembershipRepository = new TransactionMembershipRepository(_context));
        }
        public ITokenGeneratorRepository GetTokenRepository()
        {
            return _tokenGeneratorRepository ?? (_tokenGeneratorRepository = new JwtGenerator());
        }
    }
}
