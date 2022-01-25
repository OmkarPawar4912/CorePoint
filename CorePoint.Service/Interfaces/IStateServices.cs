using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface IStateServices
    {
        void CreateState(State state);
        void Delete(int? id);
        void EditState(State state);
        ViewModelState GetDetailsById(int? id);
        IEnumerable<ViewModelState> GetList();
        bool StateExists(int id);
    }
}
