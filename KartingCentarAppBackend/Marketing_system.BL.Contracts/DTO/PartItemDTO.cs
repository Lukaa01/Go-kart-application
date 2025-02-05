using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class PartItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CartService_id { get; set; }
        public int Part_id { get; set; }
        public PartDTO Part {  get; set; }
    }
}
