using DomainLayer.Bookings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainLayer.Rooms;
using DomainLayer.Users;

namespace DataLayer.DataMappers
{
    public class RoomBookingMapper : IRoomBookingMapper
    {
        private readonly IDatabase _database;
        private readonly IRoomMapper _roomMapper;
        private readonly IUserMapper _userMapper;
        public RoomBookingMapper(IDatabase database, IRoomMapper roomMapper, IUserMapper userMapper)
        {
            _database = database;
            _roomMapper = roomMapper;
            _userMapper = userMapper;
        }
        public RoomBooking Create(RoomBooking booking)
        {
            string SQL_COMMAND_TEXT = "INSERT INTO RoomBooking (StartDate, EndDate, Note, NumberOfPersons, [Status], UserId, RoomId) OUTPUT INSERTED.ID " +
                "values (@StartDate, @EndDate, @Note, @NumberOfPersons, @Status, @UserId, @RoomId)";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);

            

            command.Parameters.AddWithValue("StartDate", booking.StartDate);
            command.Parameters.AddWithValue("EndDate", booking.EndDate);
            command.Parameters.AddWithValue("NumberOfPersons", booking.NumberOfPersons);
            command.Parameters.AddWithValue("Status", booking.Status);
            command.Parameters.AddWithValue("UserId", booking.User.Id);
            command.Parameters.AddWithValue("RoomId", booking.Room.Id);
            if (booking.Note == null)
                command.Parameters.AddWithValue("Note", DBNull.Value);
            else
                command.Parameters.AddWithValue("Note", booking.Note);


            booking.Id = _database.ExecuteScalar(command);

            _database.Close();

            

            return booking;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<RoomBooking> GetByDateSpan(DateTime start, DateTime end)
        {
            string SQL_COMMAND_TEXT = "SELECT rb.id as bookingId,* FROM RoomBooking rb " +
                "WHERE rb.StartDate < @end and @start < rb.EndDate";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("start", start.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("end", end.ToString("yyyy-MM-dd"));
            SqlDataReader reader = _database.ExecuteReader(command);
            Collection<RoomBooking> bookings = new Collection<RoomBooking>();
            while (reader.Read())
            {
                RoomBooking booking = new RoomBooking();
                booking.Id = reader.GetInt32(reader.GetOrdinal("bookingId"));
                booking.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                booking.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));

                if (reader.IsDBNull(reader.GetOrdinal("CheckIn")))
                    booking.CheckIn = null;
                else
                    booking.CheckIn = reader.GetDateTime(reader.GetOrdinal("CheckIn"));

                if (reader.IsDBNull(reader.GetOrdinal("CheckOut")))
                    booking.CheckOut = null;
                else
                    booking.CheckOut = reader.GetDateTime(reader.GetOrdinal("CheckOut"));

                if (reader.IsDBNull(reader.GetOrdinal("Note")))
                    booking.Note = null;
                else
                    booking.Note = reader.GetString(reader.GetOrdinal("Note"));

                booking.NumberOfPersons = reader.GetInt32(reader.GetOrdinal("NumberOfPersons"));
                booking.Status = reader.GetFieldValue<RoomBooking.RoomBookingStatus>(reader.GetOrdinal("Status"));

                booking.Room = new Room();
                booking.Room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));
                booking.Room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));

                booking.User = new User();
                booking.User.Id = reader.GetInt32(reader.GetOrdinal("UserId"));

                bookings.Add(booking);
            }

            _database.Close();

            return bookings;
        }

        public ICollection<RoomBooking> GetAll()
        {
            string SQL_COMMAND_TEXT = "SELECT rb.id as bookingId, rt.Name as RoomTypeName, u.Name as UserName,* FROM RoomBooking rb " +
                "left join Room r on r.id = rb.RoomId " +
                "left join [User] u on u.id = rb.UserId " +
                "left join RoomType rt on r.RoomTypeId = rt.id ";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            SqlDataReader reader = _database.ExecuteReader(command);
            Collection<RoomBooking> bookings = new Collection<RoomBooking>();
            while (reader.Read())
            {
                RoomBooking booking = new RoomBooking();
                booking.Id = reader.GetInt32(reader.GetOrdinal("bookingId"));
                booking.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                booking.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                if (reader.IsDBNull(reader.GetOrdinal("CheckIn")))
                    booking.CheckIn = null;
                else
                    booking.CheckIn = reader.GetDateTime(reader.GetOrdinal("CheckIn"));

                if (reader.IsDBNull(reader.GetOrdinal("CheckOut")))
                    booking.CheckOut = null;
                else
                    booking.CheckOut = reader.GetDateTime(reader.GetOrdinal("CheckOut"));

                if (reader.IsDBNull(reader.GetOrdinal("Note")))
                    booking.Note = null;
                else
                    booking.Note = reader.GetString(reader.GetOrdinal("Note"));

                booking.NumberOfPersons = reader.GetInt32(reader.GetOrdinal("NumberOfPersons"));
                booking.Status = reader.GetFieldValue<RoomBooking.RoomBookingStatus>(reader.GetOrdinal("Status"));

                booking.Room = new Room();
                booking.Room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));
                booking.Room.Label = reader.GetString(reader.GetOrdinal("Label"));
                booking.Room.RoomType = new RoomType();
                booking.Room.RoomType.Id = reader.GetInt32(reader.GetOrdinal("RoomTypeId"));
                booking.Room.RoomType.Name = reader.GetString(reader.GetOrdinal("RoomTypeName"));

                booking.User = new User();
                booking.User.Id = reader.GetInt32(reader.GetOrdinal("UserId"));
                booking.User.Name = reader.GetString(reader.GetOrdinal("UserName"));



                bookings.Add(booking);
            }
            
            _database.Close();

            return bookings;
        }

        public RoomBooking GetById(int id)
        {
            string SQL_COMMAND_TEXT = "SELECT rb.id as bookingId, rt.Name as RoomTypeName, u.Name as UserName, i.id as InvoiceId, r.Status as RoomStatus, * " +
                "FROM RoomBooking rb " +
                "left join Room r on r.id = rb.RoomId " +
                "left join [User] u on u.id = rb.UserId " +
                "left join RoomType rt on r.RoomTypeId = rt.id " +
                "left join Invoice i on i.RoomBookingId = rb.id " +
                "WHERE rb.Id = @bookingId";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("bookingId", id);
            SqlDataReader reader = _database.ExecuteReader(command);
            RoomBooking booking = new RoomBooking();
            if (reader.Read())
            {
                booking.Id = reader.GetInt32(reader.GetOrdinal("bookingId"));
                booking.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                booking.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));

                if (reader.IsDBNull(reader.GetOrdinal("CheckIn")))
                    booking.CheckIn = null;
                else
                    booking.CheckIn = reader.GetDateTime(reader.GetOrdinal("CheckIn"));

                if (reader.IsDBNull(reader.GetOrdinal("CheckOut")))
                    booking.CheckOut = null;
                else
                    booking.CheckOut = reader.GetDateTime(reader.GetOrdinal("CheckOut"));

                if (reader.IsDBNull(reader.GetOrdinal("Note")))
                    booking.Note = null;
                else
                    booking.Note = reader.GetString(reader.GetOrdinal("Note"));

                booking.NumberOfPersons = reader.GetInt32(reader.GetOrdinal("NumberOfPersons"));
                booking.Status = reader.GetFieldValue<RoomBooking.RoomBookingStatus>(reader.GetOrdinal("Status"));

                booking.Room = new Room();
                booking.Room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));
                booking.Room.Label = reader.GetString(reader.GetOrdinal("Label"));
                booking.Room.RoomType = new RoomType();
                booking.Room.RoomType.Id = reader.GetInt32(reader.GetOrdinal("RoomTypeId"));
                booking.Room.RoomType.Name = reader.GetString(reader.GetOrdinal("RoomTypeName"));
                booking.Room.Status = reader.GetFieldValue<Room.RoomStatus>(reader.GetOrdinal("RoomStatus"));

                booking.User = new User();
                booking.User.Id = reader.GetInt32(reader.GetOrdinal("UserId"));
                booking.User.Name = reader.GetString(reader.GetOrdinal("UserName"));
                booking.User.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                booking.User.Email = reader.GetString(reader.GetOrdinal("Email"));


                booking.Invoice = new Invoice();
                if (!reader.IsDBNull(reader.GetOrdinal("UnitPrice")))
                {
                    booking.Invoice.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                    booking.Invoice.AccomodadtionPrice = reader.GetDecimal(reader.GetOrdinal("AccomodationPrice"));
                    booking.Invoice.ServiceFee = reader.GetDecimal(reader.GetOrdinal("ServiceFee"));
                }
                
            }
            else
            {
                _database.Close();
                return null;
            }

            _database.Close();

            return booking;
        }

        public RoomBooking Update(RoomBooking booking)
        {
            string SQL_COMMAND_TEXT = "UPDATE RoomBooking SET " +
                "StartDate=@StartDate, EndDate=@EndDate, CheckIn=@CheckIn, CheckOut=@CheckOut, Note=@Note, NumberOfPersons=@NumberOfPersons, [Status]=@Status, UserId=@UserId, RoomId=@RoomId " +
                "WHERE id=@id";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("UserId", booking.User.Id);
            command.Parameters.AddWithValue("StartDate", booking.StartDate);
            command.Parameters.AddWithValue("EndDate", booking.EndDate);
            command.Parameters.AddWithValue("NumberOfPersons", booking.NumberOfPersons);
            command.Parameters.AddWithValue("Status", booking.Status);
            command.Parameters.AddWithValue("RoomId", booking.Room.Id);
            command.Parameters.AddWithValue("id", booking.Id);
            if (booking.Note == null)
                command.Parameters.AddWithValue("Note", DBNull.Value);
            else
                command.Parameters.AddWithValue("Note", booking.Note);

            if (booking.CheckIn == null)
                command.Parameters.AddWithValue("CheckIn", DBNull.Value);
            else
                command.Parameters.AddWithValue("CheckIn", booking.CheckIn);

            if (booking.CheckOut == null)
                command.Parameters.AddWithValue("CheckOut", DBNull.Value);
            else
                command.Parameters.AddWithValue("CheckOut", booking.CheckOut);

            _database.ExecuteNonQuery(command);

            _database.Close();

            return booking;
        }

        public ICollection<RoomBooking> GetByUserId(int userId)
        {
            string SQL_COMMAND_TEXT = "SELECT rb.id as bookingId, rt.Name as RoomTypeName, * FROM RoomBooking rb " +
                "left join Room r on r.id = rb.RoomId " +
                "left join [User] u on u.id = rb.UserId " +
                "left join RoomType rt on r.RoomTypeId = rt.id " +
                "WHERE rb.UserId = @UserId";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("UserId", userId);
            SqlDataReader reader = _database.ExecuteReader(command);
            Collection<RoomBooking> bookings = new Collection<RoomBooking>();
            while (reader.Read())
            {
                RoomBooking booking = new RoomBooking();
                booking.Id = reader.GetInt32(reader.GetOrdinal("bookingId"));
                booking.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                booking.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));

                if (reader.IsDBNull(reader.GetOrdinal("CheckIn")))
                    booking.CheckIn = null;
                else
                    booking.CheckIn = reader.GetDateTime(reader.GetOrdinal("CheckIn"));

                if (reader.IsDBNull(reader.GetOrdinal("CheckOut")))
                    booking.CheckOut = null;
                else
                    booking.CheckOut = reader.GetDateTime(reader.GetOrdinal("CheckOut"));

                if (reader.IsDBNull(reader.GetOrdinal("Note")))
                    booking.Note = null;
                else
                    booking.Note = reader.GetString(reader.GetOrdinal("Note"));

                booking.NumberOfPersons = reader.GetInt32(reader.GetOrdinal("NumberOfPersons"));
                booking.Status = reader.GetFieldValue<RoomBooking.RoomBookingStatus>(reader.GetOrdinal("Status"));

                booking.Room = new Room(); 
                booking.Room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));
                booking.Room.RoomType = new RoomType();
                booking.Room.RoomType.Id = reader.GetInt32(reader.GetOrdinal("RoomTypeId"));
                booking.Room.RoomType.Name = reader.GetString(reader.GetOrdinal("RoomTypeName"));

                booking.User = new User();
                booking.User.Id = reader.GetInt32(reader.GetOrdinal("UserId"));

                bookings.Add(booking);
            }

            _database.Close();

            return bookings;
        }
    }
}
