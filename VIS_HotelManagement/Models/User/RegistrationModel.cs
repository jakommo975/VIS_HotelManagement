using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIS_HotelManagement.Models
{
    public class RegistrationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public bool CanLogin { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}
