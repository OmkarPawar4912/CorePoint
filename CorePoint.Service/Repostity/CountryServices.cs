using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePoint.Service.Repostity
{
    public class CountryServices : ICountryServices
    {
        private readonly ApplicationContext _context;
        public CountryServices(ApplicationContext context)
        {
            _context = context;
        }
        public async Task GetListAsync()
        {
            await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetDetailsByIdAsync(int? id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);          
            return country;
        }

        public async Task CreateCountryAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task EditCountry(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();             
        }

        public async Task DeleteAsync(int? id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }

        public bool CountryExists(int id)
        {
           return _context.Countries.Any(e => e.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
