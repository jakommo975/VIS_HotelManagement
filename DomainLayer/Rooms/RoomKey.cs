using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Users;

namespace DomainLayer.Rooms
{
    public class RoomKey
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public DateTime IssuedAt { get; set; }
        public bool Active { get; set; }
        public bool IsMaster { get; set; }
        public int RoomId { get; set; }
        public User IssuedBy { get; set; }
    }
}
