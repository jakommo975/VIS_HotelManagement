using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class RoomTypeModel
    {
        public string Id { get; set; }
        public int MaxCapacity { get; set; }
        public string Description { get; set; }
        public string BookingPrice { get; set; }
        public string Name { get; set; }
        public string TotalPrice { get; set; }
        public string ServiceFee { get; set; }

        public string ShortDescription { get; set; }
    }
}
