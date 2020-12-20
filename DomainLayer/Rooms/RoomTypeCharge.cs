using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Rooms
{
    public class RoomTypeCharge
    {
        public RoomType RoomType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal AccommodationPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ServiceFee { get; set; }
        public int DurationInNights { get; set; }

        public int NumberOfPersons { get; set; }
    }
}
