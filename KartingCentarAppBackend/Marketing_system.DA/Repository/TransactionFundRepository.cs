using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;

namespace Marketing_system.DA.Repository
{
    public class TransactionFundRepository : Repository<TransactionFund>, ITransactionFundRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public TransactionFundRepository(DataContext context) : base(context)
        {

        }
    }
}
