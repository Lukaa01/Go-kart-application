using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class PartRequestDTO
    {
        public int Id {  get; set; }
        public double Quantity { get; set; }
        public string? Name { get; set; }
        public string? Producer { get; set; }
        public PartDTO Part { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
