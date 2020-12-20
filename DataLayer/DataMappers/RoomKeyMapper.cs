using DomainLayer.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DataLayer.DataMappers
{
    public class RoomKeyMapper : IRoomKeyMapper
    {
        private readonly IDatabase _database;
        public RoomKeyMapper(IDatabase database)
        {
            _database = database;
        }

        public RoomKey Create(RoomKey roomKey)
        {
            string SQL_COMMAND_TEXT = "INSERT INTO RoomKey (issuedAt, active, isMaster, roomId, issuedBy) OUTPUT INSERTED.ID " +
                "VALUES (@issuedAt, @active, @isMaster, @roomId, @issuedBy)";
            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.CommandText = SQL_COMMAND_TEXT;
            command.Parameters.AddWithValue("issuedAt", roomKey.IssuedAt);
            command.Parameters.AddWithValue("active", roomKey.Active);
            command.Parameters.AddWithValue("isMaster", roomKey.IsMaster);
            command.Parameters.AddWithValue("roomId", roomKey.RoomId);
            command.Parameters.AddWithValue("issuedBy", roomKey.IssuedBy.Id);
            roomKey.Id = (int)_database.ExecuteScalar(command);

            _database.Close();

            return roomKey;
        }
    }
}
