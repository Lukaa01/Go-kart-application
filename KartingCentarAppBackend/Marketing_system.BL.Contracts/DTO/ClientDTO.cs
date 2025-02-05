using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public int NumberOfReservations { get; set; }
        public int PenaltyPoints { get; set; }
    }
}
