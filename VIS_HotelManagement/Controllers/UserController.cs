using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using VIS_HotelManagement.Models;
using DomainLayer.Users;
using ServiceLayer;
using VIS_HotelManagement.Factories;

namespace VIS_HotelManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserFactory _userFactory;
        public UserController(IUserService userService, IUserFactory userFactory)
        {
            _userService = userService;
            _userFactory = userFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            User user = _userService.ValidateUser(loginModel.Email, loginModel.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                loginModel.Succes = false;
                loginModel.Message = "Wrong email or password!";
                return View(loginModel);
            }
                
        }


        public IActionResult Register()
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.CanLogin = false;
            return View(registrationModel);
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel registrationModel)
        {
            string name = registrationModel.Name;
            string phone = registrationModel.Phone;
            string password = registrationModel.Password;
            string email = registrationModel.Email;

            if (_userService.UserExists(email))
            {
                registrationModel.Success = false;
                registrationModel.Message = "Account with this email already exists.";
                return View(registrationModel);
            }

            _userService.RegisterUser(name, email, phone, password);
            registrationModel.CanLogin = true;
            return View(registrationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(LoginModel loginModel)
        {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");
        }


        public IActionResult MyAccount()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            string email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            User user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Login", "User");
            }

            MyAccountModel model = _userFactory.PrepareMyAccountModel(user);

            ViewBag.Message = TempData["Message"];

            return View(model);
        }
    }
}
