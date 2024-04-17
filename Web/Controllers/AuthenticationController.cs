using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer;
using BusinessLayer;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;
        private UserManager<Accounts> _userManager;
        private SignInManager<Accounts> _signInManager;

        public AuthenticationController(DataManager dataManager, UserManager<Accounts> userManager, SignInManager<Accounts> signInManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAccount(string login, string email, string name, string surname, string phoneNumber, int day, int month, int year, string password)
        {
            if (email.EndsWith("@mail.ru") && phoneNumber.StartsWith("+") && password.Length >= 10)
            {
                if (!Regex.IsMatch(login, @"^[a-zA-Z0-9_\-.]+$"))
                    return BadRequest("Логин содержит недопустимые символы");

                if (!Regex.IsMatch(phoneNumber, @"^\+\d+$"))
                    return BadRequest("Номер телефона не соответствует формату");

                var user1 = await _userManager.FindByNameAsync(login);
                if (user1 == null)
                {
                    DateOnly date = new DateOnly(year, month, day);

                    ViewVisitors visitor = await _servicesManager.visitors.SaveEdit(
                        new EditVisitors()
                        {
                            name = name,
                            surname = surname,
                            phoneNumber = phoneNumber,
                            emailAddress = email,
                            dateOfBirth = date
                        });

                    Accounts user = new Accounts()
                    {
                        visitorID = visitor.ID,
                        UserName = login,
                        password = password,
                        registrationDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    };

                    var result = await _userManager.CreateAsync(user, password);


                    if (result.Succeeded)
                    {
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Visitor"));
                        return Redirect("/login");
                    }
                    return BadRequest("Ошибка при создании пользователя");
                }
                return BadRequest("Данный логин уже занят");
            }
            return BadRequest("Некоторые данные неккоректны");
        }

        [HttpPost]
        public async Task<IActionResult> LoginAccount(string login, string password)
        {
            var user = await _userManager.FindByNameAsync(login);


            if(user == null)
                return BadRequest("Пользователь не найден");

            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);

            if (result.Succeeded)
                return Redirect("/");
            else
                return BadRequest("Неверный пароль");
        }
    }
}
