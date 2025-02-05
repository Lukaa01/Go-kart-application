using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class PriceListItem : Entity
    {
        public string Name { get; set; }
        public int Amount {  get; set; }
        public PriceListItem() { }
        public PriceListItem(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
        public PriceListItem(int id, string name, int amount)
        {
            Id = id;
            Name = name;
            Amount = amount;
        }
    }
}
