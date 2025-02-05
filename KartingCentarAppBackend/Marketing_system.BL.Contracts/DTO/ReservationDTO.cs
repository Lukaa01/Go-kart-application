using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class ReservationDTO
    {
        public int Id {  get; set; }
        public int NumberOfPeople { get; set; }
        public ClientDTO? Client { get; set; }
        public AppointmentDTO Appointment { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public bool IsPaid {  get; set; }
    }
}
