using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Rooms;
using System.Collections.ObjectModel;

namespace DataLayer.DataMappers
{
    public interface IRoomMapper
    {
        Room Create(Room room);
        bool Delete(int id);
        ICollection<Room> GetAll();
        Collection<Room> GetByRoomTypeId(int id);
        Room GetById(int id);
        Room Update(Room room);

        Room GetByLabel(string label);
    }
}
