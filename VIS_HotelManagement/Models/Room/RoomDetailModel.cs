using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class RoomDetailModel
    {
        public List<string> ShortDescriptions;
        public RoomDetailModel()
        {
            RoomType = new RoomTypeModel();
            ShortDescriptions = new List<string>();
        }
        public RoomTypeModel RoomType { get; set; }
        public string Accomodationprice { get; set; }
        public string ServiceFee { get; set; }
        public string TotalPrice { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationInNights { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
