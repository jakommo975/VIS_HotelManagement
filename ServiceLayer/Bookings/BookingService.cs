using DomainLayer.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataMappers;
using DomainLayer.Users;
using DomainLayer.Rooms;

namespace ServiceLayer.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly IRoomTypeMapper _roomTypeMapper;
        private readonly IRoomMapper _roomDataMapper;
        private readonly IRoomBookingMapper _roomBookingMapper;
        private readonly IInvoiceMapper _invoiceMapper;
        private readonly IRoomService _roomService;

        public BookingService(IRoomTypeMapper roomTypeMapper, 
            IRoomMapper roomDataMapper, 
            IRoomBookingMapper roomBookingMapper, 
            IRoomService roomService,
            IInvoiceMapper invoiceMapper)
        {
            _roomDataMapper = roomDataMapper;
            _roomTypeMapper = roomTypeMapper;
            _roomBookingMapper = roomBookingMapper;
            _roomService = roomService;
            _invoiceMapper = invoiceMapper;
        }


        public List<RoomBooking> GetBookingsByDateSpan(DateTime start, DateTime end)
        {
            List<RoomBooking> bookings1 = _roomBookingMapper.GetAll().ToList();
            List<RoomBooking> bookings = _roomBookingMapper.GetAll().Where(x => x.StartDate < end && start < x.EndDate).ToList();
            return bookings;
        }

        public RoomBooking BookRoom(int roomTypeId, DateTime start, DateTime end, int numberOfPersons ,User user, string note)
        {
            RoomBooking booking = new RoomBooking();

            var availableRooms = _roomService.GetAvailableRoomsForDateSpan(roomTypeId, start,end);

            if (availableRooms.Count < 1)
            {
                return null;
            }

            Room room = availableRooms.FirstOrDefault();

            booking.Room = room;
            booking.User = user;
            booking.StartDate = start;
            booking.EndDate = end;
            booking.Note = note;
            booking.NumberOfPersons = numberOfPersons;
            booking.Status = RoomBooking.RoomBookingStatus.Confirmed;

            booking = _roomBookingMapper.Create(booking);

            Invoice invoice = new Invoice();
            invoice.RoomBookingId = booking.Id;
            invoice.ServiceFee = (decimal)booking.NumberOfPersons * room.RoomType.SERVICE_FEE_PER_PERSON;
            invoice.AccomodadtionPrice = (decimal)booking.DurationInNights * room.RoomType.BookingPrice;
            invoice.UnitPrice = room.RoomType.BookingPrice;
            invoice.IssuedAt = DateTime.Now;
            invoice.Status = Invoice.InvoiceStatus.Paid;

            _invoiceMapper.Create(invoice);

           

            return booking;
        }

        public bool CanBookingBeCanceled(RoomBooking booking, User user)
        {
            if (booking.StartDate.AddDays(-2) > DateTime.Now)
            {
                return true;
            }

            return false;
        }

        public bool CanUserCancelBooking(RoomBooking booking, User user)
        {
            if (booking.User.Id == user.Id || user.AccountType == User.AccountTypes.Manager || user.AccountType == User.AccountTypes.Receptionist)
            {
                return true;
            }

            return false;
        }

        public RoomBooking GetRoomBookingById(int id)
        {
            return _roomBookingMapper.GetById(id);
        }

        public List<RoomBooking> GetBookingsByUserId(int userId)
        {
            return _roomBookingMapper.GetByUserId(userId).ToList();
        }

        public void CancelBooking(RoomBooking booking)
        {
            booking.Status = RoomBooking.RoomBookingStatus.Cancelled;
            _roomBookingMapper.Update(booking);
        }

        public List<RoomBooking> GetAllBaookings()
        {
            return _roomBookingMapper.GetAll().ToList(); ;
        }

        public bool CanCheckIn(RoomBooking booking)
        {
            if (booking.Status != RoomBooking.RoomBookingStatus.Confirmed)
                return false;

            if (booking.StartDate.Date.CompareTo(DateTime.Now.Date) == -1)
                return false;

            if (booking.EndDate.CompareTo(DateTime.Now.Date) <= 0)
                return false;

            return true;
        }

        public void CheckIn(RoomBooking booking)
        {   
            booking.Status = RoomBooking.RoomBookingStatus.CheckedIn;
            booking.CheckIn = DateTime.Now;
             _roomBookingMapper.Update(booking);
        }
        public bool CanCheckOut(RoomBooking booking)
        {
            if (booking.Status != RoomBooking.RoomBookingStatus.CheckedIn)
                return false;

            return true;
        }
        public void CheckOut(RoomBooking booking)
        {
            booking.Status = RoomBooking.RoomBookingStatus.CheckedOut;
            booking.CheckOut = DateTime.Now;
            _roomBookingMapper.Update(booking);
        }

        public void ChangeRoom(RoomBooking booking, int roomId)
        {
            booking.Room = _roomDataMapper.GetById(roomId);

            _roomBookingMapper.Update(booking);
        }

        public void ConfirmBooking(RoomBooking booking)
        {
            booking.Status = RoomBooking.RoomBookingStatus.Confirmed;
            _roomBookingMapper.Update(booking);
        }

        
    }
}
