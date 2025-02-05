using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? StreetNumber { get; set; }
        public DateOnly? Birthday { get; set; }
        public DateOnly? EmploymentDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public ICollection<Training> Trainings { get; set; } = new List<Training>();
        public ICollection<CartService> Services { get; set; } = new List<CartService>();
        public Employee() { }
        public Employee(string name, string surname, string email, string password, string? phone, string? city, string? street, string? streetNumber, DateOnly? birthday, DateOnly? employmentDate, string status, string type)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Phone = phone;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            Birthday = birthday;
            EmploymentDate = employmentDate;
            Status = status;
            Type = type;
        }
        public Employee(int id, string name, string surname, string email, string password, string? phone, string? city, string? street, string? streetNumber, DateOnly? birthday, DateOnly? employmentDate, string status, string type)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Phone = phone;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            Birthday = birthday;
            EmploymentDate = employmentDate;
            Status = status;
            Type = type;
        }
    }
}
