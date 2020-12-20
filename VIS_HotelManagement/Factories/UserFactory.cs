using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Bookings;
using DomainLayer.Users;


using VIS_HotelManagement.Models;

namespace VIS_HotelManagement.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingFactory _bookingFactory;
        public UserFactory(IBookingService bookingService, IBookingFactory bookingFactory)
        {
            _bookingService = bookingService;
            _bookingFactory = bookingFactory;
        }
        public MyAccountModel PrepareMyAccountModel(User user)
        {
            MyAccountModel model = new MyAccountModel();

            model.Name = user.Name;
            model.Email = user.Email;
            model.Id = user.Id;
            model.Phone = user.Phone;

            var userBookings = _bookingService.GetBookingsByUserId(user.Id);

            foreach(var booking in userBookings)
            {
                model.Bookings.Add(_bookingFactory.PrepareBookingModel(booking));
            }

            return model;
        }
    }
}
