using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface ICountryServices : IDisposable
    {
        public void CreateCountry(Country country);
        public void Delete(int? id);
        public void EditCountry(Country country);
        public ViewModelCountries GetDetailsById(int? id);
        public IEnumerable<ViewModelCountries> GetList();
        public bool CountryExists(int id);
        void Dispose();
        public IList<Country> GetCountryList();
    }
}
