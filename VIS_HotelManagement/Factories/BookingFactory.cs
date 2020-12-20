using DomainLayer.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIS_HotelManagement.Models;

namespace VIS_HotelManagement.Factories
{
    public class BookingFactory : IBookingFactory
    {
        public BookingModel PrepareBookingModel(RoomBooking booking)
        {
            BookingModel model = new BookingModel();
            model.Id = booking.Id;
            model.CheckIn = booking.CheckIn;
            model.CheckOut = booking.CheckOut;
            model.StartDate = booking.StartDate;
            model.EndDate = booking.EndDate;
            model.DurationInNights = booking.DurationInNights;
            model.NumberOfPersons = booking.NumberOfPersons;
            model.RoomType = booking.Room.RoomType.Name;
            model.Status = booking.Status.ToString("g");

            return model;
        }
    }
}
