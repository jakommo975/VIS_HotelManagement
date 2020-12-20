using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DomainLayer.Rooms;

namespace DataLayer.DataMappers
{
    public class RoomMapper : IRoomMapper
    {
        private readonly IDatabase _database;
        public RoomMapper(IDatabase database)
        {
            _database = database;
        }

        public Room Create(Room room)
        {
            string SQL_COMMAND_TEXT = "INSERT INTO Room ([status], [label], roomTypeId) OUTPUT INSERTED.ID VALUES (@status, @label, @roomTypeId)";
            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.CommandText = SQL_COMMAND_TEXT;
            command.Parameters.AddWithValue("status", room.Status);
            command.Parameters.AddWithValue("label", room.Label);
            command.Parameters.AddWithValue("roomTypeId", room.RoomType.Id);
            room.Id = (int)_database.ExecuteScalar(command);

            _database.Close();

            return room;
        }

        public bool Delete(int id)
        {
            string SQL_COMMAND_TEXT = "DELETE FROM Room WHERE id = @id";
            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("id", id);
            int ret = _database.ExecuteNonQuery(command);

            _database.Close();

            return ret > 0;
        }

        public ICollection<Room> GetAll()
        {
            string SQL_COMMAND_TEXT = "SELECT r.Id as RoomId, * FROM Room r " +
                "left join RoomType rt on r.RoomTypeId = rt.id";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            SqlDataReader reader = _database.ExecuteReader(command);
            Collection<Room> rooms = new Collection<Room>();
            while (reader.Read())
            {
                Room room = new Room();
                room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));
                room.Label = reader.GetString(reader.GetOrdinal("Label"));
                room.Status = reader.GetFieldValue<Room.RoomStatus>(reader.GetOrdinal("Status"));
                room.RoomType = new RoomType();
                room.RoomType.Id = reader.GetInt32(reader.GetOrdinal("RoomTypeId"));
                room.RoomType.MaxCapacity = reader.GetInt32(reader.GetOrdinal("MaxCapacity"));
                room.RoomType.BookingPrice = reader.GetDecimal(reader.GetOrdinal("BookingPrice"));
                room.RoomType.Description = reader.GetString(reader.GetOrdinal("Description"));
                room.RoomType.Name = reader.GetString(reader.GetOrdinal("Name"));

                rooms.Add(room);
            }
            _database.Close();

            return rooms;
        }



        public Collection<Room> GetByRoomTypeId(int id)
        {
            string SQL_COMMAND_TEXT = "SELECT r.id as RoomId ,* FROM Room r " +
                "left join RoomType rt on rt.id = r.RoomTypeId " +
                " WHERE RoomTypeId = @id";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = _database.ExecuteReader(command);
            Collection<Room> rooms = new Collection<Room>();

            while (reader.Read())
            {
                Room room = new Room();
                room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));
                room.Label = reader.GetString(reader.GetOrdinal("Label"));
                room.Status = reader.GetFieldValue<Room.RoomStatus>(reader.GetOrdinal("Status"));
                room.RoomType = new RoomType();
                room.RoomType.Id = reader.GetInt32(reader.GetOrdinal("RoomTypeId"));
                room.RoomType.BookingPrice = reader.GetDecimal(reader.GetOrdinal("BookingPrice"));
                room.RoomType.Name = reader.GetString(reader.GetOrdinal("Name"));
                room.RoomType.MaxCapacity = reader.GetInt32(reader.GetOrdinal("MaxCapacity")); 
                rooms.Add(room);
            }
           
            _database.Close();

            return rooms;
        }

        public Room GetById(int id)
        {
            string SQL_COMMAND_TEXT = "SELECT r.id as RoomId,* FROM Room r " +
                "left join RoomType rt on rt.id = r.RoomTypeId " +
                "WHERE r.id = @id";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = _database.ExecuteReader(command);

            Room room = new Room();

            

            if (reader.Read())
            {
                room.Id = reader.GetInt32(reader.GetOrdinal("RoomId"));
                room.Label = reader.GetString(reader.GetOrdinal("Label"));
                room.Status = reader.GetFieldValue<Room.RoomStatus>(reader.GetOrdinal("Status"));
                room.RoomType = new RoomType();
                room.RoomType.Id = reader.GetInt32(reader.GetOrdinal("RoomTypeId"));
                room.RoomType.BookingPrice = reader.GetDecimal(reader.GetOrdinal("BookingPrice"));
                room.RoomType.Name = reader.GetString(reader.GetOrdinal("Name"));
                room.RoomType.MaxCapacity = reader.GetInt32(reader.GetOrdinal("MaxCapacity"));
            }
            else
            {
                _database.Close();
                return null;
            }


            _database.Close();

            return room;
        }

        public Room Update(Room room)
        {
            string SQL_COMMAND_TEXT = "UPDATE Room SET [status]=@status, [label]=@label, roomTypeId=@roomTypeId " +
                "WHERE id=@id";
            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.CommandText = SQL_COMMAND_TEXT;
            command.Parameters.AddWithValue("id", room.Id);
            command.Parameters.AddWithValue("status", room.Status);
            command.Parameters.AddWithValue("label", room.Label);
            command.Parameters.AddWithValue("roomTypeId", room.RoomType.Id);
            _database.ExecuteNonQuery(command);

            _database.Close();

            return room;
        }

        public Room GetByLabel(string label)
        {
            string SQL_COMMAND_TEXT = "SELECT * FROM Room " +
                "WHERE label=@label";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("label", label);
            SqlDataReader reader = _database.ExecuteReader(command);

            Room room = new Room();

            if (reader.Read())
            {
                room.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                room.Label = reader.GetString(reader.GetOrdinal("Label"));
                room.Status = reader.GetFieldValue<Room.RoomStatus>(reader.GetOrdinal("Status"));
            }
            else
            {
                _database.Close();
                return null;
            }


            _database.Close();

            return room;
        }
    }
}
