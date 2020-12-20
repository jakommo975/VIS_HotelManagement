using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Users;
using DomainLayer.Rooms;

namespace DomainLayer.Bookings
{
    public class RoomBooking
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DurationInNights
        {
            get
            {
                TimeSpan span = EndDate - StartDate;
                return (int)span.TotalDays;
            }
        }

        public DateTime ?CheckIn { get; set; }
        public DateTime ?CheckOut { get; set; }
        public string Note { get; set; }
        public int NumberOfPersons { get; set; }

        
        public User User { get; set; }
        public Room Room { get; set; }
        public RoomBookingStatus Status { get; set; }

        public Invoice Invoice { get; set; }
        public enum RoomBookingStatus
        {
            Confirmed = 1,
            CheckedIn = 2,
            CheckedOut = 3,
            Cancelled = 4
        }
    }
}
