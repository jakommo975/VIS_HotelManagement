using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIS_HotelManagement.Models;
using DomainLayer.Rooms;

namespace VIS_HotelManagement.Factories
{
    public interface IRoomFactory
    {
        SearchResultModel PrepareSearchResultModel(SearchModel searchModel);
        string GetShortDescription(RoomType roomType);
        RoomTypeModel PrepareRoomTypeModel(RoomType roomType, int durationInNights);

        RoomDetailModel PrepareRoomDetailModel(int id, SearchModel searchModel);

        PriceModel PreparePriceModel(int roomTypeId, DateTime startDate, DateTime endDate, int numberOfPersons);

        BookingPreviewModel PrepareBookingPreviewModel(SearchModel searchModel);
    }
}
