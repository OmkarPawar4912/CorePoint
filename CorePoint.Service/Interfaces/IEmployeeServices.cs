using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface IEmployeeServices : IDisposable
    {
        List<SelectListItem> GetddlBoold();
        IEnumerable<ViewModelEmployee> GetddlEmplList();
        List<SelectListItem> GetddlShift();
        IEnumerable<ViewModelEmployee> GetddlSupervisorList();
        List<SelectListItem> GetddlSeverityList();
        List<SelectListItem> GetddlIncidentList();
        void Delete(string id);
    }
}