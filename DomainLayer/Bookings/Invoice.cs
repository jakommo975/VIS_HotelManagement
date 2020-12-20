using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Users;

namespace DomainLayer.Bookings
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime IssuedAt { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal AccomodadtionPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int RoomBookingId { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return AccomodadtionPrice + ServiceFee;
            }
        }
        public InvoiceStatus Status { get; set; }

        public enum InvoiceStatus
        {
            Paid = 1,
            Pending = 2,
            Cancelled = 3
        }
    }
}
