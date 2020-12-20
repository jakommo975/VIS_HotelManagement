using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class BookingPreviewModel
    {
        public BookingPreviewModel()
        {
            PriceModel = new PriceModel();
            RoomType = new RoomTypeModel();
        }
        public PriceModel PriceModel { get; set; }
        public RoomTypeModel RoomType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationInNights { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
