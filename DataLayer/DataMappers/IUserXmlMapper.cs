using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Users;

namespace DataLayer.DataMappers
{
    public interface IUserXmlMapper
    {
        void SaveGuests(List<User> users, string fileName);
    }
}
