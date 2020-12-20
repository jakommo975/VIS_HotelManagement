using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class MyAccountModel
    {
        public MyAccountModel()
        {
            Bookings = new List<BookingModel>();
        }

        public List<BookingModel> Bookings { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }

    }
}
