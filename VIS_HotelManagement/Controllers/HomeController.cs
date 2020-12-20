using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VIS_HotelManagement.Models;
using ServiceLayer;
using VIS_HotelManagement.Factories;


namespace VIS_HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomService _roomService;
        private readonly IRoomFactory _roomFactory;

        public HomeController(ILogger<HomeController> logger, 
            IRoomFactory roomFactory,
            IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
            _roomFactory = roomFactory;
        }

        public IActionResult Index()
        {
            var user = User;
            SearchModel model = new SearchModel();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
