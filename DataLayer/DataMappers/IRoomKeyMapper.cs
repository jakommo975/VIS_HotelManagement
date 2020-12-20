using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Rooms;

namespace DataLayer.DataMappers
{
    public interface IRoomKeyMapper
    {
        RoomKey Create(RoomKey roomKey);
    }
}
