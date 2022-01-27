using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

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
            _context.SaveChanges();
            CreateIncidentStatus(incident);
        }
        public void CreateIncidentStatus(Incident incident)
        {
            IncidentStatus status = new IncidentStatus()
            {
                IncidentID = incident.Id,
                StatusID = 1,
                CreateDate = DateTime.Now,
                CreateBy = "Admin"
            };
            _context.IncidentStatuses.Add(status);
            _context.SaveChanges();
        }
        public List<ViewModelIncidentStatus> GetAllCases()
        {
            var result = (from a in _context.Incidents
                          let sample = _context.IncidentStatuses.Where(x => x.IncidentID == a.Id).OrderByDescending(c => c.CreateDate).FirstOrDefault()
                          select new ViewModelIncidentStatus
                          {
                              vmId = a.Id,
                              vmIncidentDate = a.IncidentDate,
                              vmIncidentType = a.IncidentType,
                              vmIncidentReportDate = a.CreateDate,
                              vmLateststatus = sample.StatusType.Name,
                              vmServertiy = a.Severity.ToString(),
                              vmSupervisorName = a.SupervisorUserName,
                              vmCrewEmail = a.EmailId
                          }).ToList();
            return result;
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