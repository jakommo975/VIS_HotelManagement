using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Users;

namespace DataLayer.DataMappers
{
    public interface IUserMapper
    {
        User Create(User entity);
        bool Delete(int id);
        ICollection<User> GetAll();
        List<User> GetGuests();
        User GetById(int id);
        User Update(int id, User entity);
        User GetByEmail(string email);
    }
}
