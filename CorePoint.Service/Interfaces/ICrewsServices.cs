using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface ICrewsServices : IDisposable
    {
        void CreateCrew(Crew crew);
        bool CrewExists(int id);
        void Delete(int? id);
        void Dispose();
        void EditCrew(Crew crew);
        IEnumerable<ViewModelCrews> GetddlCrews();
        ViewModelCrews GetDetailsById(int? id);
        IEnumerable<ViewModelCrews> GetList();
    }

    public interface IEmployee
    {
        //   IEnumerable<>
    }
}