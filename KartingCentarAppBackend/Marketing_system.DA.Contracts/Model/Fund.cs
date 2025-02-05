using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Fund : Entity
    {
        public int Amount { get; set; }
        public int Sponsor_id { get; set; }
        public Fund() { }
        public Fund(int amount, int sponsor_id)
        {
            Amount = amount;
            Sponsor_id = sponsor_id;
        }
    }
}
