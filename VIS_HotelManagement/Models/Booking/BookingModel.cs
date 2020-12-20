using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class BookingModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DurationInNights {get;set;}
        public DateTime ?CheckIn { get; set; }
        public DateTime ?CheckOut { get; set; }
        public string Note { get; set; }
        public int NumberOfPersons { get; set; }
        public int UserId { get; set; }
        public string RoomType { get; set; }
        public string Status { get; set; }
    }
}
