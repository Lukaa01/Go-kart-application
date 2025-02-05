using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string? AccessToken { get; set; }
    }
}
