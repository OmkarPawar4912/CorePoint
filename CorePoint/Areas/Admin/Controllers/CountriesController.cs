using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CorePoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountriesController : Controller
    {
        private readonly ICountryServices _countryServices;

        public CountriesController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }

        // GET: Admin/Countries
        public IActionResult Index()
        {
            return View(_countryServices.GetList());
        }

        // GET: Admin/Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _countryServices.GetDetailsById(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Admin/Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _countryServices.CreateCountry(country);
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Admin/Countries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _countryServices.GetDetailsById(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Admin/Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _countryServices.EditCountry(country);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_countryServices.CountryExists(country.Id))
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
            return View(country);
        }

        // GET: Admin/Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _countryServices.GetDetailsById(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Admin/Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _countryServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
