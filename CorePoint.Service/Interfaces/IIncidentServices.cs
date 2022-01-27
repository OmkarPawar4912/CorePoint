using CorePoint.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
