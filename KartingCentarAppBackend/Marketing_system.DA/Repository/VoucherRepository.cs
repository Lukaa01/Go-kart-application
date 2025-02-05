using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contexts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;
using Marketing_system.DA.Contracts.Shared;
using Microsoft.EntityFrameworkCore;

namespace Marketing_system.DA.Repository
{
    public class VoucherRepository : Repository<Voucher>, IVoucherRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public VoucherRepository(DataContext context) : base(context)
        {

        }
    }
}
