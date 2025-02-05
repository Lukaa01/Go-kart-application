using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Competition : Entity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public Competition() { }
        public Competition(string name, string description, DateTime dateAndTime)
        {
            Name = name;
            Description = description;
            DateAndTime = dateAndTime;
        }
    }
}
