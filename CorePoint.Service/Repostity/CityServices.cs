using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorePoint.Service.Repostity
{
    public class CityServices : ICityServices
    {
        private readonly ApplicationContext _context;
        public CityServices(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<ViewModelCity> GetList()
        {
            return _context.Cities.Select(s => new ViewModelCity
            {
                Id = s.Id,
                Name = s.Name,
                StateId = s.StateId,
                StateName = _context.States.Where(x => x.Id == s.StateId).FirstOrDefault().Name
            }).ToList();
        }

        public ViewModelCity GetDetailsById(int? id)
        {
            return GetList().FirstOrDefault(m => m.Id == id);
        }

        public void CreateCity(City city)
        {
            _context.Add(city);
            _context.SaveChanges();
        }

        public void EditCity(City city)
        {
            _context.Update(city);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var city = _context.Cities.Find(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
