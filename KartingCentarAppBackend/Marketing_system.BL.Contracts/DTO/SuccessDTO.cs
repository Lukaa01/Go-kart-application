using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class SuccessDTO
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public string Time { get; set; }
        public int? Compete_id { get; set; }
        public string? MemberFirstName { get; set; }
        public string? MemberLastName { get; set; }
    }
}
