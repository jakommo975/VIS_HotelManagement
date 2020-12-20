using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class SearchResultModel
    {
        public IList<RoomTypeModel> RoomTypes;
        
        public SearchResultModel()
        {
            RoomTypes = new List<RoomTypeModel>();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationInNights { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
