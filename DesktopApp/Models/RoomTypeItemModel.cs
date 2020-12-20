using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    public class RoomTypeItemModel
    {
        public int Id { get; set; }
        public int MaxCapacity { get; set; }
        public decimal BookingPrice { get; set; }
        public string Name { get; set; }
    }
}
