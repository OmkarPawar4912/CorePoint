using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CorePoint.Service.Interfaces
{
    public interface IEmployeeServices : IDisposable
    {
        List<SelectListItem> GetddlBoold();
    }
}