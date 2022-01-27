using CorePoint.DAL.Models;

namespace CorePoint.Service.Interfaces
{
    public interface IIncidentServices
    {
        void CreateIncident(Incident incident);
        bool IncidentExists(int id);
        void Delete(int? id);
        void Dispose();
        void EditCrew(Incident incident);
    }
}
