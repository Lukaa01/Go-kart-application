using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Participate : Entity
    {
        public int Member_id {  get; set; }
        public int Competition_id {  get; set; }
        public Participate() { }
        public Participate(int member_id, int competition_id)
        {
            Member_id = member_id;
            Competition_id = competition_id;
        }
    }
}
