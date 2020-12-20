using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Bookings;
using VIS_HotelManagement.Models;

namespace VIS_HotelManagement.Factories
{
    public interface IBookingFactory
    {
        BookingModel PrepareBookingModel(RoomBooking booking);
    }
}
