using CorePoint.DAL.Enums;
using CorePoint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CorePoint.Service.Repostity
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IAddressServices _addressServices;
        public EmployeeServices(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }
        public List<SelectListItem> GetddlBoold()
        {
            var blood = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-- Select Boold Type --",
                    Value = ""
                }
            };

            foreach (Blood value in Enum.GetValues(typeof(Blood)))
            {
                blood.Add(new SelectListItem { Text = Enum.GetName(typeof(Blood), value), Value = value.ToString() });
            }

            return blood;
        }
        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }
    }
}
