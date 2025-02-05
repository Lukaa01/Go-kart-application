using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class PriceListItemDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
