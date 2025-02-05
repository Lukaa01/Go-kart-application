using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Success : Entity
    {
        public int Place {  get; set; }
        public string Time {  get; set; }
        public int? Compete_id {  get; set; }
        public Success() { }
        public Success(int place, string time, int? competes_id)
        {
            Place = place;
            Time = time;
            Compete_id = competes_id;
        }
    }
}
