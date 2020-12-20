using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIS_HotelManagement.Models;
using ServiceLayer;
using VIS_HotelManagement.Factories;
using DomainLayer.Rooms;


namespace VIS_HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;
        private readonly IRoomFactory _roomFactory;

        public RoomController(ILogger<RoomController> logger,
            IRoomFactory roomFactory,
            IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
            _roomFactory = roomFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(SearchModel m)
        {
            SearchResultModel model = _roomFactory.PrepareSearchResultModel(m);
            return View(model);
        }

        public IActionResult Detail(int id, SearchModel searchModel)
        {
            RoomDetailModel model = _roomFactory.PrepareRoomDetailModel(id, searchModel);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        
        public IActionResult RoomPrices(int roomTypeId, DateTime startDate, DateTime endDate, int numberOfPersons)
        {
            PriceModel model = _roomFactory.PreparePriceModel(roomTypeId, startDate, endDate, numberOfPersons);
            return Json(model);
        }

    }
}
