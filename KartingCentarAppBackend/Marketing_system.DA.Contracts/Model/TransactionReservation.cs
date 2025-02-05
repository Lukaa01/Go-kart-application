using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class TransactionReservation : Entity
    {
        public int Reservation_id {  get; set; }
        public TransactionReservation() { }
        public TransactionReservation(int id, int reservation_id)
        {
            Id = id;
            Reservation_id = reservation_id;
        }
    }
}
