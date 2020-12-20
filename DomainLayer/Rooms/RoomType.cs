using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Rooms
{
    public class RoomType
    {
        public readonly decimal SERVICE_FEE_PER_PERSON = (decimal)8.0;

        public readonly decimal SERVICE_FEE_PER_CHILD = (decimal)2.0;

        public int Id { get; set; }
        public int MaxCapacity { get; set; }
        public string Description { get; set; }
        public decimal BookingPrice { get; set; }
        public string ShortDescription { get; set; }
        public string Name { get; set; }
    }
}
