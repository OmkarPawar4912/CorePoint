using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorePoint.Service.Repostity
{
    public class CountryServices : ICountryServices
    {
        private readonly ApplicationContext _context;
        public CountryServices(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<ViewModelCountries> GetList()
        {
            return _context.Countries.Select(s => new ViewModelCountries
            {
                Id = s.Id,
                Name = s.Name
            }).ToList().OrderBy(x => x.Name);
        }

        public IEnumerable<Country> GetListCountry()
        {
            return _context.Countries.ToList();
        }

        public ViewModelCountries GetDetailsById(int? id)
        {
            return GetList().FirstOrDefault(m => m.Id == id);
        }

        public void CreateCountry(Country country)
        {
            _context.Add(country);
            _context.SaveChanges();
        }

        public void EditCountry(Country country)
        {
            _context.Update(country);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var country = _context.Countries.Find(id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }

        public IList<Country> GetCountryList()
        {
            return _context.Countries.OrderBy(x => x.Name).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
