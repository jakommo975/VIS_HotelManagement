using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DomainLayer.Rooms;

namespace DataLayer.DataMappers
{
    public interface IRoomTypeMapper
    {
        RoomType Create(RoomType roomType);

        bool Delete(int id);

        ICollection<RoomType> GetAll();

        RoomType GetById(int id);

        RoomType Update(RoomType roomType);
    }
}
