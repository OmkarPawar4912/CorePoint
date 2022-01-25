using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CorePoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CitiesController : Controller
    {
        private readonly ICityServices _cityServices;

        public CitiesController(ICityServices cityServices)
        {
            _cityServices = cityServices;
        }

        // GET: Admin/Cities
        public IActionResult Index()
        {
            return View(_cityServices.GetList().ToList());
        }

        // GET: Admin/Cities/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityServices.GetDetailsById(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Admin/Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                _cityServices.CreateCity(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Admin/Cities/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityServices.GetDetailsById(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Admin/Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,StateId")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _cityServices.EditCity(city);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_cityServices.CityExists(city.Id))
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
            return View(city);
        }

        // GET: Admin/Cities/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityServices.GetDetailsById(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Admin/Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cityServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
