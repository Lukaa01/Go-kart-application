using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class DebtDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public bool IsPaid {  get; set; }
        public int Member_id { get; set; }
    }
}
