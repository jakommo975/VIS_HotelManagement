using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Rooms
{
    public class Room
    {
        public int Id { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType RoomType { get; set; }
        public string Label { get; set; }

        public List<RoomKey> RoomKeys {get;set;}
        public enum RoomStatus
        {
            Available = 1,
            Occupied = 2,
            BeingServiced = 3,
            Unavailable = 4
        }
    }
}
