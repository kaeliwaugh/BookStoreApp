using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Services;

namespace BookstoreApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAuthenticationService _authService;

        public UserController(IUserAuthenticationService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_authService.Login(username, password)) 
                return RedirectToAction("Index", "Book");

            ViewBag.ErrorMessage = "Invalid, try again";
            return View();
        }

        public IActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction("Login");
        }

    }
}
