using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DomainLayer.Rooms;
using DataLayer.DataMappers;
using ServiceLayer.Bookings;
using DomainLayer.Users;

namespace ServiceLayer
{
    public class RoomService : IRoomService
    {

        private readonly IRoomTypeMapper _roomTypeMapper;
        private readonly IRoomMapper _roomDataMapper;
        private readonly IRoomBookingMapper _bookingMapper;
        private readonly IRoomKeyMapper _roomKeyMapper;

        public RoomService(IRoomTypeMapper roomTypeMapper, IRoomMapper roomDataMapper,  IRoomBookingMapper bookingMapper, IRoomKeyMapper roomKeyMapper)
        {
            _roomDataMapper = roomDataMapper;
            _roomTypeMapper = roomTypeMapper;
            _bookingMapper = bookingMapper;
            _roomKeyMapper = roomKeyMapper;
        }
        public List<Room> GetRooms()
        { 
            List<Room> rooms = _roomDataMapper.GetAll().ToList();

            return rooms;
        }

        public List<RoomType> GetAvailableRoomTypesForDateSpan(DateTime start, DateTime end, int numberofPersons)
        {
            List<RoomType> roomTypes = _roomTypeMapper.GetAll().Where(x => x.MaxCapacity >= numberofPersons).ToList();

            List<RoomType> availableRoomTypes = new List<RoomType>();

            var bookings = _bookingMapper.GetByDateSpan(start, end);
            var bookedRoomIds = bookings.Select(x => x.Id);

            foreach (var type in roomTypes)
            {
                var roomsByType = _roomDataMapper.GetByRoomTypeId(type.Id);
                var intersection = roomsByType.Select(x => x.Id).Intersect(bookedRoomIds);

                if (intersection.ToList().Count < roomsByType.Count)
                {
                    availableRoomTypes.Add(type);
                }
            }

            return availableRoomTypes;
        }

        public RoomType GetRoomTypeById(int id)
        {
            RoomType roomType = _roomTypeMapper.GetById(id);
            roomType.ShortDescription = GetShortDescription(roomType);
            return roomType;
        }

        public RoomTypeCharge GetRoomTypeWithPrices(int roomTypeId, DateTime startDate, DateTime endDate, int numberOfPersons)
        {
            RoomType roomType = GetRoomTypeById(roomTypeId);

            RoomTypeCharge roomTypeCharge = new RoomTypeCharge();

            roomTypeCharge.RoomType = roomType;
            TimeSpan span = endDate - startDate;

            int durationInNights = (int)span.TotalDays;
            decimal accomodationprice = roomType.BookingPrice * durationInNights;

            decimal serviceFee = (decimal)numberOfPersons * roomType.SERVICE_FEE_PER_PERSON;

            decimal totalPrice = serviceFee + accomodationprice;

            roomTypeCharge.ServiceFee = serviceFee;
            roomTypeCharge.AccommodationPrice = accomodationprice;
            roomTypeCharge.TotalPrice = totalPrice;
            roomTypeCharge.DurationInNights = durationInNights;
            roomTypeCharge.EndDate = endDate;
            roomTypeCharge.StartDate = startDate;
            roomTypeCharge.NumberOfPersons = numberOfPersons;

            return roomTypeCharge;
        }

        public List<Room> GetAvailableRoomsForDateSpan(int roomTypeId, DateTime start, DateTime end)
        {

            var bookings = _bookingMapper.GetByDateSpan(start, end);

            var bookedRoomsIds = bookings.Select(x => x.Room.Id);

            var roomsByType = _roomDataMapper.GetByRoomTypeId(roomTypeId);

            var availableRooms = roomsByType.Where(x => !bookedRoomsIds.Contains(x.Id));


            if (availableRooms.ToList().Count < 1)
            {
                return null;
            }

            return availableRooms.ToList();
        }

        public string GetShortDescription(RoomType roomType)
        {
            switch (roomType.Id)
            {
                case 1:
                    return "2 single beds, 1 bathroom, WiFi";
                case 2:
                    return "1 king-size bed, 3 single beds, flat TV screen, WiFi, 2 bathrooms";
                case 3:
                    return "3 single beds, konerence room, 2 bathrooms, flat TV screen, WiFi, mini bar";
                case 4:
                    return "1 king-size bed, 1 bathroom, flat TV screen, WiFi, bathtub, mini bar";
                case 5:
                    return "2 king-size beds, 2 bathroom, flat TV screen, WiFi, bathtub, mini bar";
                default:
                    return "WiFi";
            }
        }

        public bool IsRoomReady(int roomId)
        {
            /*
            if (room.Status != Room.RoomStatus.Available)
                return false;
            */
            return true;
        }

        public RoomKey IssueRoomKey(int roomId, int userId)
        {
            RoomKey roomKey = new RoomKey();
            roomKey.IssuedBy = new User { Id = userId};
            roomKey.RoomId = roomId;
            roomKey.IssuedAt = DateTime.Now;

            return _roomKeyMapper.Create(roomKey);
        }
        
        public List<RoomType> GetRoomTypes()
        {
            return _roomTypeMapper.GetAll().ToList();
        }


        public Room AddRoom(string label, int roomTypeId)
        {
            Room room = new Room();
            room.Label = label;

            room.RoomType = new RoomType { Id = roomTypeId };
            room.Status = Room.RoomStatus.Available;

            return _roomDataMapper.Create(room);
        }

        public RoomType AddRoomType(decimal price, string name, string description, int maxCapacity)
        {
            RoomType roomType = new RoomType();
            roomType.BookingPrice = price;
            roomType.Name = name;
            roomType.Description = description;
            roomType.MaxCapacity = maxCapacity;

            return _roomTypeMapper.Create(roomType);
        }

        public bool IsLabelUnique(string label)
        {
            if (_roomDataMapper.GetByLabel(label) == null)
                return true;
            else
                return false;
        }
        public Room GetRoomById(int id)
        {
            return _roomDataMapper.GetById(id);
        }

        public Room EditRoom(Room room)
        {
            return _roomDataMapper.Update(room);
        }

        public RoomType EditeRoomType(RoomType roomType)
        {
            return _roomTypeMapper.Update(roomType);
        }
    }
}
