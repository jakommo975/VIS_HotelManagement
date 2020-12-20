using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Bookings;
using ServiceLayer;
using DomainLayer.Users;
using DomainLayer.Bookings;
using VIS_HotelManagement.Models;
using VIS_HotelManagement.Factories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace VIS_HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRoomFactory _roomFactory;
        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;
        public BookingController(IRoomFactory roomFactory, IBookingService bookingService, IUserService userService)
        {
            _bookingService = bookingService;
            _roomFactory = roomFactory;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Preview(SearchModel searchModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            BookingPreviewModel model = _roomFactory.PrepareBookingPreviewModel(searchModel);

            return View(model);
        }

        [HttpPost]
        public IActionResult Book(SearchModel searchModel, string note)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            string email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            User user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Login", "User");
            }

            RoomBooking booking = _bookingService.BookRoom(searchModel.RoomTypeId, searchModel.StartDate, searchModel.EndDate, searchModel.NumberOfPersons, user, note);
            
            return RedirectToAction("MyAccount", "User");
        }

        [HttpPost]
        public IActionResult CancelBooking(int bookingId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            string email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            
            User user = _userService.GetUserByEmail(email);

            if (user == null)
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Login", "User");
            }


            RoomBooking booking = _bookingService.GetRoomBookingById(bookingId);

            if (booking == null)
            {
                TempData["Message"] = "Somehting went wrong.";
            }

            if (!_bookingService.CanBookingBeCanceled(booking, user))
            {
                TempData["Message"] = "Booking must be cancelled at least 2 days before start date.";
                return RedirectToAction("MyAccount", "User");
            }

            if (!_bookingService.CanUserCancelBooking(booking, user))
            {
                TempData["Message"] = "You are not authorized for this action.";
                return RedirectToAction("MyAccount", "User");
            }

            _bookingService.CancelBooking(booking);
            
            return RedirectToAction("MyAccount", "User");
        }
    }
}
