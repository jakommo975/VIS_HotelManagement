using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class SearchModel
    {
        public IList<RoomTypeModel> RoomTypes;

        public SearchModel()
        {
            RoomTypes = new List<RoomTypeModel>();
        }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfPersons { get; set; }
        public int RoomTypeId { get; set; }
    }
}
