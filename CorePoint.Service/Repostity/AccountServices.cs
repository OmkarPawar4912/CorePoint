using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CorePoint.Service.Repostity
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateUserAsync(ViewModelSignUp viewModel)
        {
            var user = new Employee()
            {
                Email = viewModel.Email,
                UserName = viewModel.Email
            };
            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                //var token = await _userManager.GenerateChangeEmailTokenAsync();
            }
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(ViewModelLogin viewModel)
        {
            return await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, true);
        }

        public async Task<IdentityRole> GetRoleByNameAsync(string userName)
        {
            return await _roleManager.FindByNameAsync(userName);
        }
    }
}
