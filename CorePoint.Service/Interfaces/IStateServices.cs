using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePoint.Service.Interfaces
{
    public interface IStateServices
    {
        void CreateState(State state);
        void Delete(int? id);
        void EditCountry(State state);
        ViewModelState GetDetailsById(int? id);
        IEnumerable<ViewModelState> GetList();
        bool StateExists(int id);
    }
}
