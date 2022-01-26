using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CorePoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CrewsController : Controller
    {
        private readonly ICrewsServices _crewsServices;

        public CrewsController(ICrewsServices crewsServices)
        {
            _crewsServices = crewsServices;
        }

        // GET: Admin/Crews
        public IActionResult Index()
        {
            return View(_crewsServices.GetList().ToList());
        }

        // GET: Admin/Crews/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = _crewsServices.GetDetailsById(id);
            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // GET: Admin/Crews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Crews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Code,Sitecode,CreateBy,CreateDate,UpdateBy,UpdateDate")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                _crewsServices.CreateCrew(crew);
                return RedirectToAction(nameof(Index));
            }
            return View(crew);
        }

        // GET: Admin/Crews/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = _crewsServices.GetDetailsById(id);
            if (crew == null)
            {
                return NotFound();
            }
            return View(crew);
        }

        // POST: Admin/Crews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Code,Sitecode,CreateBy,CreateDate,UpdateBy,UpdateDate")] Crew crew)
        {
            if (id != crew.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _crewsServices.EditCrew(crew);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_crewsServices.CrewExists(crew.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(crew);
        }

        // GET: Admin/Crews/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = _crewsServices.GetDetailsById(id);
            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // POST: Admin/Crews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _crewsServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
