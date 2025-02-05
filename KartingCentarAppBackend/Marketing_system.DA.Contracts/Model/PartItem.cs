using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class PartItem : Entity
    {
        public int Quantity {  get; set; }
        public int CartService_id {  get; set; }
        public int Part_id { get; set; }
        public Part Part { get; set; }
        public CartService CartService { get; set; }
        public PartItem() { }
        public PartItem(int quantity, int cartService_id, int part_id)
        {
            Quantity = quantity;
            CartService_id = cartService_id;
            Part_id = part_id;
        }
    }
}
