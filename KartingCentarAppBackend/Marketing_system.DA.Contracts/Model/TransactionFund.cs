using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class TransactionFund : Entity
    {
        public int Fund_id { get; set; }
        public TransactionFund() { }
        public TransactionFund(int id, int fund_id)
        {
            Id = id;
            Fund_id = fund_id;
        }
    }
}
