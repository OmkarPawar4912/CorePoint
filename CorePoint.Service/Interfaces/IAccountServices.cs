using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CorePoint.Service.Interfaces
{
    public interface IAccountServices
    {
        Task<IdentityResult> CreateUserAsync(ViewModelSignUp viewModel);
        Task<SignInResult> PasswordSignInAsync(ViewModelLogin viewModel);
        Task<IdentityRole> GetRoleByNameAsync(string userName);
    }
}