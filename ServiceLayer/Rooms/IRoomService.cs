using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Rooms;

namespace ServiceLayer
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        List<RoomType> GetAvailableRoomTypesForDateSpan(DateTime start, DateTime end, int numberOfPersons);
        List<RoomType> GetRoomTypes();
        Room GetRoomById(int id);
        RoomType GetRoomTypeById(int id);
        RoomTypeCharge GetRoomTypeWithPrices(int roomTypeId, DateTime startDate, DateTime endDate, int numberOfPersons);
        string GetShortDescription(RoomType roomType);
        List<Room> GetAvailableRoomsForDateSpan(int roomTypeId, DateTime start, DateTime end);
        bool IsRoomReady(int roomId);
        RoomKey IssueRoomKey(int roomId, int userId);
        Room AddRoom(string label, int roomTypeId);
        RoomType AddRoomType(decimal price, string name, string description, int maxCapacity);

        bool IsLabelUnique(string label);

        Room EditRoom(Room room);
        RoomType EditeRoomType(RoomType roomType);
    }
}
