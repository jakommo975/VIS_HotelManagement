using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    public class BookingItemModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DurationInNights { get; set; }

        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int NumberOfPersons { get; set; }


        public string GuestName { get; set; }
        public string RoomLabel { get; set; }
        public string Status { get; set; }
    }
}
