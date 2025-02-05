using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Part : Entity
    {
        public string Name {  get; set; }
        public string Producer {  get; set; }
        public double Total {  get; set; }
        public PartRequest PartRequest { get; set; }
        public ICollection<PartItem> PartItems { get; set; } = new List<PartItem>();
        public Part() { }
        public Part(string name, string producer, double total)
        {
            Name = name;
            Producer = producer;
            Total = total;
        }
        public Part(int id, string name, string producer, double total)
        {
            Id = id;
            Name = name;
            Producer = producer;
            Total = total;
        }
    }
}
