using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Track : Entity
    {
        public string Name { get; set; }
        public int Length {  get; set; }
        public string Record {  get; set; }
        public Track() { }
        public Track(string name, int length, string record)
        {
            Name = name;
            Length = length;
            Record = record;
        }
    }
}
