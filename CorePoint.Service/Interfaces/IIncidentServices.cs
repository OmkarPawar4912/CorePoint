using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorePoint.Service.Interfaces
{
    public interface IIncidentServices
    {
        void CreateIncident(Incident incident);
        void Delete(int id);
        void Dispose();
        List<ViewModelIncidentStatus> GetIncidentIndexList();
        IList<StatusType> StatusdlList();
        List<ViewModelIncidentStatus> GetListById(int? id);
        ViewModelIncidentStatus DisplayStatusById(int id);
        void ChangeIncidentStatus(ViewModelIncidentStatus viewModel);
        IQueryable<ViewModelIncidentStatus> GetSearchResults(ViewModelSearch searchModel);
    }
}