using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface IStateServices : IDisposable
    {
        void CreateState(State state);
        void Delete(int? id);
        void EditState(State state);
        ViewModelState GetDetailsById(int? id);
        IEnumerable<ViewModelState> GetList();
        bool StateExists(int id);
        void Dispose();
        IList<State> GetStatesByCountryId(int countryId);
    }
}