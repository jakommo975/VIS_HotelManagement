using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainLayer.Users;
using VIS_HotelManagement.Models;

namespace VIS_HotelManagement.Factories
{
    public interface IUserFactory
    {
        MyAccountModel PrepareMyAccountModel(User user);
    }
}
