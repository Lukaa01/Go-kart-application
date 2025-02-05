using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class CompetitionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public List<SuccessDTO> Success { get; set; }  
    }
}
