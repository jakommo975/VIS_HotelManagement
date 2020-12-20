using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DomainLayer.Rooms;
using System.Configuration;


namespace DataLayer.DataMappers
{
    public class RoomTypeMapper : IRoomTypeMapper
    {
        private readonly IDatabase _database;
        public RoomTypeMapper(IDatabase database)
        {
            _database = database;
        }

        public RoomType Create(RoomType roomType)
        {
            string SQL_COMMAND_TEXT = "INSERT INTO RoomType (maxCapacity, description, BookingPrice, [Name]) OUTPUT INSERTED.ID VALUES (@maxCapacity, @description, @bookingPrice, @name)";

            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("maxCapacity", roomType.MaxCapacity);
            command.Parameters.AddWithValue("description", roomType.Description);
            command.Parameters.AddWithValue("bookingPrice", roomType.BookingPrice);
            command.Parameters.AddWithValue("name", roomType.Name);

            roomType.Id = (int)command.ExecuteScalar();

            _database.Close();
            return roomType;
        }

        public bool Delete(int id)
        {
            string SQL_COMMAND_TEXT = "DELETE FROM RoomType WHERE id = @id";

            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("id", id);
            _database.Close();
            return command.ExecuteNonQuery() > 0;

        }

        public ICollection<RoomType> GetAll()
        {
            string SQL_COMMAND_TEXT = "SELECT * FROM RoomType";
            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            SqlDataReader reader = command.ExecuteReader();
            Collection<RoomType> roomTypes = new Collection<RoomType>();
            while (reader.Read())
            {
                RoomType roomType = new RoomType
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    BookingPrice = reader.GetDecimal(reader.GetOrdinal("BookingPrice")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    MaxCapacity = reader.GetInt32(reader.GetOrdinal("MaxCapacity")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                };
                roomTypes.Add(roomType);
            }
            _database.Close();
            return roomTypes;
        }

        public RoomType GetById(int id)
        {
            string SQL_COMMAND_TEXT = "SELECT * FROM RoomType WHERE id = @id";
            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader();
            RoomType roomType = new RoomType();
            if (reader.Read())
            {
                roomType.Id = id;
                roomType.MaxCapacity = reader.GetInt32(reader.GetOrdinal("MaxCapacity"));
                roomType.Description = reader.GetString(reader.GetOrdinal("Description"));
                roomType.BookingPrice = reader.GetDecimal(reader.GetOrdinal("BookingPrice"));
                roomType.Name = reader.GetString(reader.GetOrdinal("Name"));
            }
            else
            {
                _database.Close();
                return null;
            }

            _database.Close();
            return roomType;
        }

        public RoomType Update(RoomType roomType)
        {
            string SQL_COMMAND_TEXT =  "UPDATE RoomType SET maxCapacity=@maxCapacity, description=@description, bookingPrice=@bookingPrice, [name]=@name " +
                "WHERE id=@id";

            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("id", roomType.Id);
            command.Parameters.AddWithValue("maxCapacity", roomType.MaxCapacity);
            command.Parameters.AddWithValue("description", roomType.Description);
            command.Parameters.AddWithValue("bookingPrice", roomType.BookingPrice);
            command.Parameters.AddWithValue("name", roomType.Name);

            _database.ExecuteNonQuery(command);

            _database.Close();
            return roomType;
        }
    }
}
