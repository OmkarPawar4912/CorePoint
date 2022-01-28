using CorePoint.DAL.Models;
using CorePoint.Service.ViewModel;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface IIncidentServices
    {
        void CreateIncident(Incident incident);
        bool IncidentExists(int id);
        void Delete(int? id);
        void Dispose();
        void EditCrew(Incident incident);
        List<ViewModelIncidentStatus> GetIncidentIndexList();
        IList<StatusType> StatusdlList();
        List<ViewModelIncidentStatus> GetListById(int? id);
        ViewModelIncidentStatus DisplayStatusById(int id);
        void ChangeIncidentStatus(ViewModelIncidentStatus viewModel);
    }
}