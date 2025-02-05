using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class TransactionMembership : Entity
    {
        public int Membership_id {  get; set; }
        public TransactionMembership() { }
        public TransactionMembership(int transaction_id, int membership_id)
        {
            Id = transaction_id;
            Membership_id = membership_id;
        }
    }
}
