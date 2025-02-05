using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Vozilo : Entity
    {
        [Column("marka")]
        public string Marka { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("kubikaza")]
        public int Kubikaza { get; set; }
        [Column("upotrebljivo")]
        public bool Upotrebljivo { get; set; }
        public int BrojVozila {  get; set; }

        public Vozilo() { }
        public Vozilo(string mar, string mod, int kub, bool up, int brojVozila)
        {
            Marka = mar;
            Model = mod;
            Kubikaza = kub;
            Upotrebljivo = up;
            BrojVozila = brojVozila;
        }

        public Vozilo(int id, string mar, string mod, int kub, bool up, int brojVozila)
        {
            Id = id;
            Marka = mar;
            Model = mod;
            Kubikaza = kub;
            Upotrebljivo = up;
            BrojVozila = brojVozila;
        }
    }
}
