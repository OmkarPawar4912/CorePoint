using CorePoint.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorePoint.Service.Interfaces
{
    public interface ICountryServices :IDisposable
    {
        Task CreateCountryAsync(Country country);
        Task DeleteAsync(int? id);
        Task EditCountry(Country country);
        Task<Country> GetDetailsByIdAsync(int? id);
        Task GetListAsync();
        bool CountryExists(int id);
    }
}
