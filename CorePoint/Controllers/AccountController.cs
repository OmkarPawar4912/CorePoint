using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([Bind("Email,Password")] ViewModelLogin modelLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.PasswordSignInAsync(modelLogin);
                if (result.Succeeded)
                {
                    if ("admin@gmail.com"==modelLogin.Email.ToLower())
                    {
                        return LocalRedirect("~/Admin/Home/Index");
                    }
                    else
                    {
                        return LocalRedirect("~/Home/ComingSoon");
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
