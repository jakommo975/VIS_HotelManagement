using DomainLayer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataMappers;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly IUserMapper _userMapper;
        private readonly IUserXmlMapper _userXmlMapper;
        public UserService(IUserMapper userMapper, IUserXmlMapper userXmlMapper)
        {
            _userMapper = userMapper;
            _userXmlMapper = userXmlMapper;
        }

        public User RegisterUser(string name, string email, string phone, string password, User.AccountStatus status = User.AccountStatus.Active, User.AccountTypes type = User.AccountTypes.Guest)
        {
            User user = new User();
            user.Name = name;
            user.Email = email;
            user.Phone = phone;
            user.Password = password;
            user.AccountType = type;
            user.UserAccountStatus = status;

            return _userMapper.Create(user);
            
        }

        public User ValidateUser(string email, string password)
        {
            User user = _userMapper.GetByEmail(email);

            if (user != null && user.Password.Equals(password) && user.UserAccountStatus == User.AccountStatus.Active)
            {
                return user;
            }

            else
            {
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            User user = _userMapper.GetByEmail(email);

            return user;
        }

        public bool UserExists(string email)
        {
            User user = _userMapper.GetByEmail(email);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public User GetUserById(int id)
        {
            return _userMapper.GetById(id);
        }

        public List<User> GetGuests()
        {
            return _userMapper.GetGuests();
        }

        public void ExportGuestsToXml(string filePath)
        {
            var guests = _userMapper.GetGuests();
            _userXmlMapper.SaveGuests(guests, filePath);
        }
    }
}
