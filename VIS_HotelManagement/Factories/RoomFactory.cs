using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIS_HotelManagement.Models;
using DomainLayer.Rooms;
using ServiceLayer;

namespace VIS_HotelManagement.Factories
{
    public class RoomFactory : IRoomFactory
    {
        private readonly IRoomService _roomService;

        public RoomFactory(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public SearchResultModel PrepareSearchResultModel(SearchModel searchModel)
        {
            var roomTypes = _roomService.GetAvailableRoomTypesForDateSpan(searchModel.StartDate, searchModel.EndDate, searchModel.NumberOfPersons);
            SearchResultModel model = new SearchResultModel();
            model.StartDate = searchModel.StartDate;
            model.EndDate = searchModel.EndDate;

            model.NumberOfPersons = searchModel.NumberOfPersons;

            TimeSpan span = searchModel.EndDate - searchModel.StartDate;

            int durationInNights = (int)span.TotalDays;

            model.DurationInNights = durationInNights;

            foreach (var roomType in roomTypes)
            {
                RoomTypeModel roomTypeModel = PrepareRoomTypeModel(roomType, durationInNights);
                model.RoomTypes.Add(roomTypeModel);
            }

            return model;
        }

        public RoomTypeModel PrepareRoomTypeModel(RoomType roomType, int durationInNights)
        {

            RoomTypeModel roomTypeModel = new RoomTypeModel();

            roomTypeModel.BookingPrice = roomType.BookingPrice.ToString("#.##");
            roomTypeModel.Name = roomType.Name;
            roomTypeModel.Id = roomType.Id.ToString();
            roomTypeModel.MaxCapacity = roomType.MaxCapacity;
            roomTypeModel.Description = roomType.Description.ToString();

            decimal totalPrize = roomType.BookingPrice * durationInNights;
            roomTypeModel.TotalPrice = totalPrize.ToString("#.##");

            roomTypeModel.ShortDescription = GetShortDescription(roomType);

            return roomTypeModel;
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
                    return null;
            }
        }

        public RoomDetailModel PrepareRoomDetailModel(int id, SearchModel searchModel)
        {
            RoomType roomType = _roomService.GetRoomTypeById(id);
            if (roomType == null)
                return null;
            RoomDetailModel model = new RoomDetailModel();

            model.ShortDescriptions = roomType.ShortDescription.Split(",").ToList().Select(x => x.Trim()).ToList();
            model.StartDate = searchModel.StartDate;
            model.EndDate = searchModel.EndDate;
            model.NumberOfPersons = searchModel.NumberOfPersons;
            TimeSpan span = searchModel.EndDate - searchModel.StartDate;

            int durationInNights = (int)span.TotalDays;
            decimal accomodationprice = roomType.BookingPrice * durationInNights;
            model.Accomodationprice = accomodationprice.ToString("#.##");
            model.DurationInNights = durationInNights;
            decimal serviceFee = (decimal)searchModel.NumberOfPersons * roomType.SERVICE_FEE_PER_PERSON;
            model.ServiceFee = serviceFee.ToString("#.##");
            model.TotalPrice = (serviceFee + accomodationprice).ToString("#.##");

            model.RoomType = PrepareRoomTypeModel(roomType, durationInNights);



            return model;
        }

        public PriceModel PreparePriceModel(int roomTypeId, DateTime startDate, DateTime endDate, int numberOfPersons)
        {
            if (startDate >= endDate)
            {
                endDate = startDate.AddDays(1);
            }
            RoomTypeCharge roomTypeCharge = _roomService.GetRoomTypeWithPrices(roomTypeId, startDate, endDate, numberOfPersons);
            PriceModel model = new PriceModel();

            model.AccomodationPrice = roomTypeCharge.AccommodationPrice.ToString("#.##");
            model.ServiceFee = roomTypeCharge.ServiceFee.ToString("#.##");
            model.TotalPrice = roomTypeCharge.TotalPrice.ToString("#.##");
            return model;
        }

        public BookingPreviewModel PrepareBookingPreviewModel(SearchModel searchModel)
        {
            BookingPreviewModel model = new BookingPreviewModel();

            model.PriceModel = PreparePriceModel(searchModel.RoomTypeId, searchModel.StartDate, searchModel.EndDate, searchModel.NumberOfPersons);

            TimeSpan span = searchModel.EndDate - searchModel.StartDate;
            int durationInNights = (int)span.TotalDays;

            model.DurationInNights = durationInNights;
            model.EndDate = searchModel.EndDate;
            model.StartDate = searchModel.StartDate;
            model.NumberOfPersons = searchModel.NumberOfPersons;

            RoomType roomType = _roomService.GetRoomTypeById(searchModel.RoomTypeId);
            model.RoomType = PrepareRoomTypeModel(roomType, durationInNights);

            return model;
        }
    }
}
