using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class FinancialTransactionDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
