using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using System;

namespace CorePoint.Service.Repostity
{
    public class IncidentServices : IIncidentServices
    {
        private readonly ApplicationContext _context;
        public IncidentServices(ApplicationContext context)
        {
            _context = context;
        }
        public void CreateIncident(Incident incident)
        {
            incident.CreateDate = DateTime.Now;
            incident.UpdateDate = DateTime.Now;
            incident.CreateBy = "Admin";
            incident.UpdateBy = "Admin";
            _context.Add(incident);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditCrew(Incident incident)
        {
            throw new NotImplementedException();
        }

        public bool IncidentExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}