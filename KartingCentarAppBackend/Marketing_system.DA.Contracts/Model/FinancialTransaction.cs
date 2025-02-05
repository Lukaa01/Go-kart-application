using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class FinancialTransaction : Entity
    {
        public int Amount {  get; set; }
        public DateOnly Date {  get; set; }
        public string Description {  get; set; }
        public string Type { get; set; }
        public FinancialTransaction() { }
        public FinancialTransaction(int amount, DateOnly date, string description, string type)
        {
            Amount = amount;
            Date = date;
            Description = description;
            Type = type;
        }

        public FinancialTransaction(int id, int amount, DateOnly date, string description, string type)
        {
            Id = id;
            Amount = amount;
            Date = date;
            Description = description;
            Type = type;
        }
    }
}
