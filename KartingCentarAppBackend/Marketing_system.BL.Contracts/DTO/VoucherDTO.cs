using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class VoucherDTO
    {
        public int Id {  get; set; }
        public string ExpirationDate { get; set; }
        public int Discount { get; set; }
        public int Client_id { get; set; }
    }
}
