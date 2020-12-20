using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    public class Database : IDatabase
    {
        private readonly string _connectionString = "server=dbsys.cs.vsb.cz\\STUDENT;database=bys0043;user=bys0043;password=oS7HTvNcUb;";
        private SqlConnection Connection { get; set; }
        private SqlTransaction SqlTransaction { get; set; }

        public Database()
        {
            Connection = new SqlConnection();
        }

        public bool Connect(string conString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            return true;
        }

        public bool Connect()
        {
            bool ret = true;
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                // connection string is stored in file App.config or Web.config
                ret = Connect(_connectionString);
            }
            return ret;
        }

        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        /// <summary>
        /// End a transaction.
        /// </summary>
        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public SqlDataReader ExecuteReader(SqlCommand command)
        {
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }

        public int ExecuteScalar(SqlCommand command)
        {
            int ret = (int)command.ExecuteScalar();
            return ret;
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int ret = command.ExecuteNonQuery();
            return ret;
        }
    }
}
