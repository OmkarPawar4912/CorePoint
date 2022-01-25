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


        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(ViewModelSignUp viewSignUp)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.CreateUserAsync(viewSignUp);

                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(viewSignUp);
                }
                ModelState.Clear();
                viewSignUp.IsSuccess = true;
            }
            return View(viewSignUp);
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
                        return RedirectToAction("Index", "Home");
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
    }
}
