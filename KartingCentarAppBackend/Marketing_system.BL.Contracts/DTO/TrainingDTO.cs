using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class TrainingDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public AppointmentDTO Appointment { get; set; }
    }
}
