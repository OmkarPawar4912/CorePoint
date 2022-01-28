using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CorePoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
        public IActionResult Index()
        { 
            return View(_incidentServices.GetIncidentIndexList());
        }

     [HttpPost]
        public IActionResult Index(ViewModelSearch viewModel)
        {
            return View(_incidentServices.GetSearchResults(viewModel));
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
        public IActionResult Create([Bind("Id,SupervisorUserName,EmailId,Shift,IncidentType,Area,Description,Severity,IncidentDate")] Incident incident)
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

        // GET: Admin/Incidents/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.StatusList = _incidentServices.StatusdlList();
            ViewBag.Data = _incidentServices.GetListById(id);
            
            if (ViewBag.Data == null)
            {
                return NotFound();
            }

            return View(_incidentServices.DisplayStatusById((int)id));
        }

        [HttpPost]
        public IActionResult Edit([Bind("vmIncidentId,vmStatusID,Remark")]ViewModelIncidentStatus viewModel)
        {
            _incidentServices.ChangeIncidentStatus(viewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _incidentServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
