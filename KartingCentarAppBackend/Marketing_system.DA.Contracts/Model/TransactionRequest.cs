using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class TransactionRequest : Entity
    {
        public int Request_id { get; set; }
        public TransactionRequest() { }
        public TransactionRequest(int id, int request_id)
        {
            Id = id;
            Request_id = request_id;
        }
    }
}
