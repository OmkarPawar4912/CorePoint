using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;

namespace CorePoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IncidentsController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ICrewsServices _crewsServices;
        private readonly IIncidentServices _incidentServices;
        private readonly ApplicationContext _context;

        public IncidentsController(ApplicationContext context, IEmployeeServices employeeServices, ICrewsServices crewsServices, IIncidentServices incidentServices)
        {
            _context = context;
            _employeeServices = employeeServices;
            _crewsServices = crewsServices;
            _incidentServices = incidentServices;
        }

        // GET: Admin/Incidents
        public async Task<IActionResult> Index()
        {
             
            return View(await _context.Incidents.ToListAsync());
        }

        // GET: Admin/Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Admin/Incidents/Create
        public IActionResult Create()
        {
            AllddlBind();
            return View();
        }
        public void AllddlBind()
        {
            ViewBag.EmpList = _employeeServices.GetddlEmplList();
            ViewBag.ShiftList = _employeeServices.GetddlShift();
            ViewBag.SupervisorList = _employeeServices.GetddlSupervisorList();
            ViewBag.SeverityList = _employeeServices.GetddlSeverityList();
            ViewBag.IncidentList = _employeeServices.GetddlIncidentList();
        }
        // POST: Admin/Incidents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,SupervisorUserName,EmailId,Shift,IncidentType,Area,Description,FilePath,Severity,IncidentDate")] Incident incident)
        {
            
            if (ModelState.IsValid)
            {
                _incidentServices.CreateIncident(incident);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                AllddlBind();
            }
            return View(incident);
        }

    }
}
