using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public AccountStatus UserAccountStatus { get; set; }
        public enum AccountStatus
        {
            Active = 1,
            Cancelled = 2,
            Blacklisted = 3
        }
        public AccountTypes AccountType { get; set; }
        public enum AccountTypes
        {
            Guest = 1,
            Receptionist = 2,
            Manager = 3
        }
    }
}
