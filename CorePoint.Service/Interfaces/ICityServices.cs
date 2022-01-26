using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface ICityServices : IDisposable
    {
        void CreateCity(City city);
        void Delete(int? id);
        void EditCity(City city);
        ViewModelCity GetDetailsById(int? id);
        IEnumerable<ViewModelCity> GetList();
        bool CityExists(int id);
        void Dispose();
        IList<City> GetCityList(int stateId);
    }
}
