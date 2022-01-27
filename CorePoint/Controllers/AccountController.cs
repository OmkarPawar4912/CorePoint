using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorePoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([Bind("Email,Password")] ViewModelLogin modelLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.PasswordSignInAsync(modelLogin);
                if (result.Succeeded)
                { 
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { Areas = "Admin" });
                    }
                    else if (User.IsInRole("Supervisor"))
                    {
                        return Content("Supervisor");
                    }
                    else
                    {
                        return Content("User");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(modelLogin);
                }
            }
            return View();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountServices.SignOutAsync();
            return LocalRedirect("~/");
        }
    }
}
