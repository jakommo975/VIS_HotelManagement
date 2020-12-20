using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Users;
using System.Data.SqlClient;

namespace DataLayer.DataMappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IDatabase _database;
        public UserMapper(IDatabase database)
        {
            _database = database;
        }
        public User Create(User user)
        {
            string SQL_COMMAND_TEXT = "INSERT INTO [User] (name, email, phone, AccountType, [password], accountstatus) OUTPUT INSERTED.ID " +
                "values (@name, @email, @phone, @AccountType, @password, @accountstatus)";

            _database.Connect();

            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("email", user.Email);
            command.Parameters.AddWithValue("phone", user.Phone);
            command.Parameters.AddWithValue("AccountType", user.AccountType);
            command.Parameters.AddWithValue("password", user.Password);
            command.Parameters.AddWithValue("accountstatus", user.UserAccountStatus);

            user.Id = _database.ExecuteScalar(command);

            _database.Close();

            return user;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            string SQL_COMMAND_TEXT = "SELECT * FROM [User] WHERE email = @email";

            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("email", email); ;

            SqlDataReader reader = _database.ExecuteReader(command);


            if (reader.Read())
            {
                User user = new User();
                user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                user.Email = email;
                user.Name = reader.GetString(reader.GetOrdinal("Name"));
                user.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                user.Password = reader.GetString(reader.GetOrdinal("Password"));
                user.UserAccountStatus = reader.GetFieldValue<User.AccountStatus>(reader.GetOrdinal("AccountStatus"));
                user.AccountType = reader.GetFieldValue<User.AccountTypes>(reader.GetOrdinal("AccountType"));
                _database.Close();
                return user;
            }
            else
            {
                _database.Close();
                return null;
            }

            
        }

        public User GetById(int id)
        {
            string SQL_COMMAND_TEXT = "SELECT * FROM [User] WHERE id = @id";

            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("id", id); 

            SqlDataReader reader = _database.ExecuteReader(command);


            if (reader.Read())
            {
                User user = new User();
                user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                user.Email = reader.GetString(reader.GetOrdinal("Email"));
                user.Name = reader.GetString(reader.GetOrdinal("Name"));
                user.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                user.Password = reader.GetString(reader.GetOrdinal("Password"));
                user.UserAccountStatus = reader.GetFieldValue<User.AccountStatus>(reader.GetOrdinal("AccountStatus"));
                user.AccountType = reader.GetFieldValue<User.AccountTypes>(reader.GetOrdinal("AccountType"));
                _database.Close();
                return user;
            }
            else
            {
                _database.Close();
                return null;
            }
        }

        public List<User> GetGuests()
        {
            string SQL_COMMAND_TEXT = "SELECT * FROM [User] WHERE AccountType=@AccountType";

            _database.Connect();
            SqlCommand command = _database.CreateCommand(SQL_COMMAND_TEXT);
            command.Parameters.AddWithValue("AccountType", User.AccountTypes.Guest);

            SqlDataReader reader = _database.ExecuteReader(command);

            List<User> guests = new List<User>();

            while (reader.Read())
            {
                User guest = new User();
                guest.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                guest.Email = reader.GetString(reader.GetOrdinal("Email"));
                guest.Name = reader.GetString(reader.GetOrdinal("Name"));
                guest.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                guest.Password = reader.GetString(reader.GetOrdinal("Password"));
                guest.UserAccountStatus = reader.GetFieldValue<User.AccountStatus>(reader.GetOrdinal("AccountStatus"));
                guest.AccountType = reader.GetFieldValue<User.AccountTypes>(reader.GetOrdinal("AccountType"));

                guests.Add(guest);
            }

            _database.Close();

            return guests;
        }

        public User Update(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
