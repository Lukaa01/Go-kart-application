using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class FundDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Sponsor_id { get; set; }
    }
}
