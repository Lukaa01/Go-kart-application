using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Client : Entity
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public string? City { get; set; }
        public string? Street {  get; set; }
        public string? StreetNumber { get; set; }
        public string? Phone { get; set; }
        public string Status {  get; set; }
        public int NumberOfReservations {  get; set; }
        public int PenaltyPoints {  get; set; }
        public ICollection<Reservation> Reservations {  get; set; }
        public Client() { }
        public Client(string name, string surname, string email, string password, string city, string street, string streetNumber, string phone, string status, int numberOfReservations, int penaltyPoints)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            Phone = phone;
            Status = status;
            NumberOfReservations = numberOfReservations;
            PenaltyPoints = penaltyPoints;
        }

        public Client(int id, string name, string surname, string email, string password, string city, string street, string streetNumber, string phone, string status, int numberOfReservations, int penaltyPoints)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            Phone = phone;
            Status = status;
            NumberOfReservations = numberOfReservations;
            PenaltyPoints = penaltyPoints;
        }
    }
}
