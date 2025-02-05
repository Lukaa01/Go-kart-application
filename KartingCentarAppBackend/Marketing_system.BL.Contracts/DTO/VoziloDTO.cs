using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_system.BL.Contracts.DTO
{
    public class VoziloDTO
    {
        public int Id {  get; set; }
        public string Marka {  get; set; }
        public string Model {  get; set; }
        public int Kubikaza {  get; set; }
        public bool Upotrebljivo {  get; set; }
        public int BrojVozila {  get; set; }

    }
}
