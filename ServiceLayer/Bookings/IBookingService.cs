using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Bookings;
using DomainLayer.Rooms;
using DomainLayer.Users;

namespace ServiceLayer.Bookings
{
    public interface IBookingService
    {
        List<RoomBooking> GetBookingsByDateSpan(DateTime start, DateTime end);
        RoomBooking BookRoom(int roomTypeId, DateTime start, DateTime end, int numberOfPersons, User user, string note);
        bool CanBookingBeCanceled(RoomBooking booking, User user);
        bool CanUserCancelBooking(RoomBooking booking, User user);
        List<RoomBooking> GetBookingsByUserId(int userId);
        RoomBooking GetRoomBookingById(int id);
        void CancelBooking(RoomBooking booking);
        List<RoomBooking> GetAllBaookings();
        bool CanCheckIn(RoomBooking booking);
        bool CanCheckOut(RoomBooking booking);
        void CheckIn(RoomBooking booking);
        void CheckOut(RoomBooking booking);
        void ChangeRoom(RoomBooking booking, int roomId);
        void ConfirmBooking(RoomBooking booking);

        
    }
}
