using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.DA.Contracts.Model
{
    public class Voucher : Entity
    {
        public DateOnly ExpirationDate {  get; set; }
        public int Discount {  get; set;  }
        public int Client_id {  get; set; }
        public Voucher() { }
        public Voucher(DateOnly expirationDate, int discount, int client_id)
        {
            ExpirationDate = expirationDate;
            Discount = discount;
            Client_id = client_id;
        }
        public Voucher(int id, DateOnly expirationDate, int discount, int client_id)
        {
            Id = id;
            ExpirationDate = expirationDate;
            Discount = discount;
            Client_id = client_id;
        }
    }
}
