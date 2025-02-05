using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Category : Entity
    {
        public string Name {  get; set; }
        public int Price {  get; set; }

        public ICollection<Member> Members = new List<Member>();
        public Category()
        {

        }
        public Category(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
