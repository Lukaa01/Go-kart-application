using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Debt : Entity
    {
        public int Amount { get; set; }
        public string Description {  get; set; }
        public bool IsPaid { get; set; }
        public int Member_id {  get; set; }
        public Debt() { }
        public Debt(int id, int amount, string description, bool isPaid, int member_id)
        {
            Id = id;
            Amount = amount;
            Description = description;
            IsPaid = isPaid;
            Member_id = member_id;
        }
    }
}
