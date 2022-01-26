using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePoint.Service.Repostity
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationContext _applicationContext;
        public AccountServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationContext applicationContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _applicationContext = applicationContext;
        }
        public async Task<IdentityResult> CreateUserAsync(ViewModelEmployee viewModel)
        {
            var user = new Employee()
            {
                FullName = viewModel.FullName,
                Email = viewModel.Email,
                UserName = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                EmergencyPhoneNumber = viewModel.EmergencyPhoneNumber,
                AddressId = viewModel.Address.Id,
                Gender = viewModel.Gender,
                DOB = viewModel.DOB,
                CrewId = viewModel.CrewId,
                HireDate = viewModel.HireDate,
                IsActive = viewModel.IsActive,
                IsSupervisior = viewModel.IsSupervisior,
                Blood = viewModel.Blood,
                CreateDate = DateTime.Now,
                CreateBy = "Admin",
                UpdateDate = DateTime.Now,
                UpdateBy = "Admin"
            };
            return await _userManager.CreateAsync(user, viewModel.Password);
        }
        public async Task<SignInResult> PasswordSignInAsync(ViewModelLogin viewModel)
        {
            return await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, true);
        }

        public async Task<IdentityRole> GetRoleByNameAsync(string userName)
        {
            return await _roleManager.FindByNameAsync(userName);
        }
        public IEnumerable<ViewModelEmployee> GetList()
        {
            return _applicationContext.Employees.Include(e => e.Address).Select(s => new ViewModelEmployee
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                Gender = s.Gender,
                CityName = s.Address.City.Name,
                CrewName = s.Crew.Name,
                IsSupervisior = s.IsSupervisior,
                HireDate = s.HireDate
            });
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

    }
}
