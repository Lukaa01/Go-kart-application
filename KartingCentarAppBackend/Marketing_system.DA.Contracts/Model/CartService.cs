using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class CartService : Entity
    {
        public DateOnly Date { get; set; }
        public string Description {  get; set; }
        public int Vehicle_id { get; set; }
        public ICollection<Employee> Servicers { get; set; } = new List<Employee>();
        public ICollection<PartItem> PartItems { get; set; } = new List<PartItem>();

        public CartService() { }

        public CartService(int id, DateOnly date, string description, int vehicle_id)
        {
            Id = id;
            Date = date;
            Description = description;
            Vehicle_id = vehicle_id;
        }
    }
}
