using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Reservation : Entity
    {
        public int NumberOfPeople {  get; set; }
        public int Client_id {  get; set; }
        public int Appointment_id {  get; set; }
        public string? Name {  get; set; }
        public string? Surname {  get; set; }
        public string? Phone {  get; set;  }
        public bool IsPaid { get; set; }
        public Appointment Appointment { get; set; }
        public Client? Client { get; set; }
        public Reservation() { }
        public Reservation(int numberOfPeople, int client_id, int appointment_id, string name, string surname, string phone, bool paid)
        {
            NumberOfPeople = numberOfPeople;
            Client_id = client_id;
            Appointment_id = appointment_id;
            Name = name;
            Surname = surname;
            Phone = phone;
            IsPaid = paid;
        }

        public Reservation(int id, int numberOfPeople, int client_id, int appointment_id, string name, string surname, string phone, bool paid)
        {
            Id = id;
            NumberOfPeople = numberOfPeople;
            Client_id = client_id;
            Appointment_id = appointment_id;
            Name = name;
            Surname = surname;
            Phone = phone;
            IsPaid = paid;
        }
    }
}
