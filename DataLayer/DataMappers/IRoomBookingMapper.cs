using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DomainLayer.Bookings;

namespace DataLayer.DataMappers
{
    public interface IRoomBookingMapper
    {
        RoomBooking Create(RoomBooking entity);
        bool Delete(int id);
        ICollection<RoomBooking> GetAll();

        ICollection<RoomBooking> GetByDateSpan(DateTime start, DateTime end);
        RoomBooking GetById(int id);
        RoomBooking Update(RoomBooking booking);

        ICollection<RoomBooking> GetByUserId(int userId);
    }
}
