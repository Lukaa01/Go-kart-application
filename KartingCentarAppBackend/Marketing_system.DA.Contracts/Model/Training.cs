using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Training : Entity
    {
        public string Type {  get; set; }
        public int Appointment_id {  get; set; }
        public ICollection<Employee> Instruktors { get; set; } = new List<Employee>();
        public ICollection<Member> Members { get; set; } = new List<Member>();
        public Appointment Appointment { get; set; }
        public Training() { }
        public Training(string type, int appointment_id)
        {
            Type = type;
            Appointment_id = appointment_id;
        }
    }
}
