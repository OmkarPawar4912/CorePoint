using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Identity;
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
        private readonly IAddressServices _addressServices;
        public AccountServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationContext applicationContext, IAddressServices addressServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _applicationContext = applicationContext;
            _addressServices = addressServices;
        }
        public async Task<IdentityResult> CreateUserAsync(ViewModelEmployee viewModel)
        {
            var address = new Address()
            {
                AddressLine = viewModel.Address.AddressLine,
                CityId = viewModel.Address.CityId,
                StateId = viewModel.Address.StateId,
                CountryId = viewModel.Address.CountryId,
                ZipCode = viewModel.Address.ZipCode,
            };

            int addressId = _addressServices.CreateAddress(address);

            var user = new Employee()
            {
                FullName = viewModel.FullName,
                Email = viewModel.Email,
                UserName = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                EmergencyPhoneNumber = viewModel.EmergencyPhoneNumber,
                Gender = viewModel.Gender,
                DOB = viewModel.DOB,
                CrewId = viewModel.CrewId,
                HireDate = viewModel.HireDate,
                AddressId = addressId,
                IsActive = viewModel.IsActive,
                IsSupervisior = viewModel.IsSupervisior,
                Blood = viewModel.Blood,
                CreateDate = DateTime.Now,
                CreateBy = "Admin",
                UpdateDate = DateTime.Now,
                UpdateBy = "Admin"
            };
            return await _userManager.CreateAsync(user, viewModel.ConfirmPassword);
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
            return _applicationContext.Employees.Where(x=>x.Email!="admin@gmail.com").Select(s => new ViewModelEmployee
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                CrewName = s.Crew.Name,
                IsSupervisior = s.IsSupervisior,
                HireDate = s.HireDate,
                IsActive = s.IsActive,
                CreateDate = s.CreateDate
            });
        }

        public void Dispose()
        {
            _applicationContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}