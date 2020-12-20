using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Users;


namespace ServiceLayer
{
    public interface IUserService
    {
        User ValidateUser(string email, string password);

        User RegisterUser(string name, string email, string phone, string password, User.AccountStatus status = User.AccountStatus.Active, User.AccountTypes type = User.AccountTypes.Guest);

        bool UserExists(string email);

        User GetUserByEmail(string email);

        User GetUserById(int id);

        List<User> GetGuests();

        void ExportGuestsToXml(string filePath);
    }
}
