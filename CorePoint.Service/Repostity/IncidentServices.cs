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
        public DateTime date = DateTime.UtcNow;
        private readonly ApplicationContext _context;
        public IncidentServices(ApplicationContext context)
        {
            _context = context;
        }

        //Status Dropdown
        public IList<StatusType> StatusdlList()
        {
            return _context.StatusTypes.ToList();
        }

        public void CreateIncident(Incident incident)
        {

            incident.CreateDate = date;
            incident.UpdateDate = date;
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
                CreateDate = date,
                CreateBy = "Admin",
                Remark = "Initiated"
            };
            _context.IncidentStatuses.Add(status);
            _context.SaveChanges();
        }

        public void ChangeIncidentStatus(ViewModelIncidentStatus viewModel)
        {
            IncidentStatus status = new IncidentStatus()
            {
                IncidentID = viewModel.vmIncidentId,
                StatusID = viewModel.vmStatusID,
                CreateBy = "Admin",
                CreateDate = date,
                Remark = viewModel.Remark
            };
            _context.IncidentStatuses.Add(status);
            _context.SaveChanges();
        }

        public List<ViewModelIncidentStatus> GetIncidentIndexList()
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
                              vmFile = a.FileUploadePath,
                              vmServertiy = a.Severity.ToString(),
                              vmSupervisorName = _context.Employees.Where(x => x.Email == a.SupervisorUserName).FirstOrDefault().FullName,
                              vmEmployeeName = _context.Employees.Where(x => x.Email == a.EmailId).FirstOrDefault().FullName,
                              vmCrew = a.EmailId
                          }).OrderByDescending(x => x.vmId).ToList();
            return result;
        }

        public List<ViewModelIncidentStatus> GetListById(int? id)
        {
            var joinResult = (from t1 in _context.Incidents.Where(w => w.Id == id)
                              join t2 in _context.IncidentStatuses
                              on t1.Id equals t2.IncidentID
                              select new ViewModelIncidentStatus
                              {
                                  vmLateststatus = _context.StatusTypes.Where(x => x.ID == t2.StatusID).FirstOrDefault().Name,
                                  vwStatusDate = t2.CreateDate,
                                  Remark = t2.Remark,
                              }).OrderByDescending(d => d.vwStatusDate).ToList();

            return joinResult;
        }

        public ViewModelIncidentStatus DisplayStatusById(int id)
        {
            var joinResult = (from t1 in _context.Incidents.Where(w => w.Id == id)
                              select new ViewModelIncidentStatus
                              {
                                  vmIncidentId = t1.Id,
                                  vmIncidentDate = t1.IncidentDate,
                                  vmIncidentType = t1.IncidentType,
                                  vmIncidentReportDate = t1.CreateDate,
                                  vmArea = t1.Area,
                                  vmFile = t1.FileUploadePath,
                                  vmSupervisorName = _context.Employees.Where(x => x.Email == t1.SupervisorUserName).FirstOrDefault().FullName,
                                  vmEmployeeName = _context.Employees.Where(x => x.Email == t1.EmailId).FirstOrDefault().FullName,
                                  viewIncidentDes = t1.Description
                              }).FirstOrDefault();
            return joinResult;
        }

        public IQueryable<ViewModelIncidentStatus> GetSearchResults(ViewModelSearch searchModel)
        {
            var result = GetIncidentIndexList().AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Name))
                    result = result.Where(x => x.vmEmployeeName.ToLower().Contains(searchModel.Name.ToLower()) || x.vmSupervisorName.ToLower().Contains(searchModel.Name.ToLower()));
                if (searchModel.FromDate.HasValue)
                    result = result.Where(x => x.vmIncidentDate >= searchModel.FromDate);
                if (searchModel.ToDate.HasValue)
                    result = result.Where(x => x.vmIncidentDate <= searchModel.ToDate);
            }
            return result;
        }

        public void Delete(int id)
        {
            var incident = _context.Incidents.Find(id);
            _context.Incidents.Remove(incident);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}