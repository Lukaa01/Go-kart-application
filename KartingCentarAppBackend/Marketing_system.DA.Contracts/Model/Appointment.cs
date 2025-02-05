using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Appointment : Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Track_id { get; set; }
        public virtual Training Training { get; set; }
        public Reservation Reservation { get; set; }

        public Appointment() { }
        public Appointment(DateTime startTime, DateTime endTime, int track_id)
        {
            StartTime = startTime;
            EndTime = endTime;
            Track_id = track_id;
        }

        public Appointment(int id, DateTime startTime, DateTime endTime, int track_id)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Track_id = track_id;
        }
    }
}
