using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CorePoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatesController : Controller
    {
        private readonly IStateServices _stateServices;
        public StatesController(IStateServices stateServices)
        {
            _stateServices = stateServices;
        }

        // GET: Admin/States
        public IActionResult Index()
        {
            return View(_stateServices.GetList().ToList());
        }

        // GET: Admin/States/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateServices.GetDetailsById(id);

            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: Admin/States/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/States/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CountryId")] State state)
        {
            if (ModelState.IsValid)
            {
                _stateServices.CreateState(state);
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        // GET: Admin/States/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateServices.GetDetailsById(id);
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }

        // POST: Admin/States/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,CountryId")] State state)
        {
            if (id != state.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _stateServices.EditState(state);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_stateServices.StateExists(state.Id))
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
            return View(state);
        }

        // GET: Admin/States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateServices.GetDetailsById(id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: Admin/States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _stateServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
