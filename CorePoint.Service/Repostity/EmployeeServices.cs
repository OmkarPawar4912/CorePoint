using CorePoint.DAL.Data;
using CorePoint.DAL.Enums;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorePoint.Service.Repostity
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationContext _context;
        public EmployeeServices(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ViewModelEmployee> GetddlEmplList()
        {
            return _context.Employees.Where(x => x.Email != "admin@gmail.com").Select(s => new ViewModelEmployee
            {
                Email = s.Email,
                FullName = s.FullName
            }).ToList().OrderBy(x => x.FullName);
        }

        public IEnumerable<ViewModelEmployee> GetddlSupervisorList()
        {
            return _context.Employees.Where(x => x.Email != "admin@gmail.com" && x.IsSupervisior).Select(s => new ViewModelEmployee
            {
                Email = s.Email,
                FullName = s.FullName
            }).ToList().OrderBy(x => x.FullName);
        }

        public List<SelectListItem> GetddlShift()
        {
            var shift = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-- Select Shift --",
                    Value = ""
                }
            };

            foreach (Shift value in Enum.GetValues(typeof(Shift)))
            {
                shift.Add(new SelectListItem { Text = Enum.GetName(typeof(Shift), value), Value = value.ToString() });
            }

            return shift;
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

        public List<SelectListItem> GetddlIncidentList()
        {
            var data = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-- Select Incident Type --",
                    Value = ""
                }
            };

            foreach (IncidentType value in Enum.GetValues(typeof(IncidentType)))
            {
                data.Add(new SelectListItem { Text = Enum.GetName(typeof(IncidentType), value), Value = value.ToString() });
            }

            return data;
        }
        public List<SelectListItem> GetddlSeverityList()
        {
            var servertiy = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-- Select Sevearity --",
                    Value = ""
                }
            };

            foreach (Servertiy value in Enum.GetValues(typeof(Servertiy)))
            {
                servertiy.Add(new SelectListItem { Text = Enum.GetName(typeof(Servertiy), value), Value = value.ToString() });
            }

            return servertiy;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Delete(string id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
