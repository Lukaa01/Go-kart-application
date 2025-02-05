using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class CartServiceDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string Description {  get; set; }
        public List<PartItemDTO> PartItems { get; set; }
        public int Vehicle_id {  get; set; }
    }
}
