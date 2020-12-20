using DomainLayer.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataLayer.DataMappers
{
    public class InvoiceMapper : IInvoiceMapper
    {
        IDatabase _database;
        public InvoiceMapper(IDatabase database)
        {
            _database = database;
        }
        public Invoice Create(Invoice invoice)
        {
            string SQL_COMMAND_TEXT = "INSERT INTO Invoice (ServiceFee, AccomodationPrice, UnitPrice, [Status], IssuedAt, RoomBookingId) OUTPUT INSERTED.ID " +
                "VALUES (@ServiceFee, @AccomodationPrice, @UnitPrice, @Status ,@IssuedAt, @RoomBookingId)";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.CommandText = SQL_COMMAND_TEXT;
            command.Parameters.AddWithValue("ServiceFee", invoice.ServiceFee);
            command.Parameters.AddWithValue("AccomodationPrice", invoice.AccomodadtionPrice);
            command.Parameters.AddWithValue("UnitPrice", invoice.UnitPrice);
            command.Parameters.AddWithValue("Status", invoice.Status);
            command.Parameters.AddWithValue("IssuedAt", invoice.IssuedAt);
            command.Parameters.AddWithValue("RoomBookingId", invoice.RoomBookingId);
            invoice.Id = _database.ExecuteScalar(command);

            _database.Close();

            return invoice;
        }
    }
}
