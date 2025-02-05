using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class PartDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Total { get; set; }
    }
}
