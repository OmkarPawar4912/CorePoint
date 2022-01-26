using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorePoint.Service.Interfaces
{
    public interface IAccountServices : IDisposable
    {
        IEnumerable<ViewModelEmployee> GetList();
        Task<IdentityResult> CreateUserAsync(ViewModelEmployee viewModel);
        Task<SignInResult> PasswordSignInAsync(ViewModelLogin viewModel);
        Task<IdentityRole> GetRoleByNameAsync(string userName);
    }
}