using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataLayer
{
    public interface IDatabase
    {
        bool Connect(string conString);
        bool Connect();
        void Close();
        void BeginTransaction();

        /// <summary>
        /// End a transaction.
        /// </summary>
        void EndTransaction();

        void Rollback();

        SqlCommand CreateCommand(string strCommand);

        SqlDataReader ExecuteReader(SqlCommand command);

        int ExecuteScalar(SqlCommand command);

        int ExecuteNonQuery(SqlCommand command);
    }
}
