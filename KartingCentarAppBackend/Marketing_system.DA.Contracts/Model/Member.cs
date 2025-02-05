using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Member : Entity
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? City {  get; set; }
        public string? Street {  get; set; }
        public string? StreetNumber { get; set; }
        public DateOnly Birthday { get; set; }
        public string Status {  get; set; }
        public int MemberCard {  get; set; }
        public int Category_id {  get; set; }
        public int Instruktor_id {  get; set; }
        public Category Category {  get; set; }
        public ICollection<Training> Trainings {  get; set; }
        public Member() { }
        public Member(string name, string surname, string email, string password, string phone, string city, string street, string streetNumber, DateOnly birthday, string status, int memberCard, int category_id, int instruktor_id)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.City = city;
            this.Street = street;
            this.StreetNumber = streetNumber;
            this.Birthday = birthday;
            this.Status = status;
            this.MemberCard = memberCard;
            this.Category_id = category_id;
            this.Instruktor_id = instruktor_id;
        }

        public Member(int id, string name, string surname, string email, string password, string phone, string city, string street, string streetNumber, DateOnly birthday, string status, int memberCard, int category_id, int instruktor_id)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.City = city;
            this.Street = street;
            this.StreetNumber = streetNumber;
            this.Birthday = birthday;
            this.Status = status;
            this.MemberCard = memberCard;
            this.Category_id = category_id;
            this.Instruktor_id = instruktor_id;
        }
    }
}
