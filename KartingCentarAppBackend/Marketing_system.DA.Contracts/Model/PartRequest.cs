using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class PartRequest : Entity
    {
        public double Quantity { get; set; }
        public string? Name {  get; set; }
        public string? Producer {  get; set; }
        public int? Part_id {  get; set; }
        public Part Part {  get; set; }
        public DateOnly Date {  get; set; }
        public string Status {  get; set; }
        public PartRequest() { }
        public PartRequest(double quantity, string name, string producer, int? part_id, DateOnly date, string status)
        {
            Quantity = quantity;
            Name = name;
            Producer = producer;
            Part_id = part_id;
            Date = date;
            Status = status;
        }
        public PartRequest(int id, double quantity, string name, string producer, int? part_id, DateOnly date, string status)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
            Producer = producer;
            Part_id = part_id;
            Date = date;
            Status = status;
        }
    }
}
