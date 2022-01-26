using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace CorePoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IAccountServices _accountServices;
        private readonly ICrewsServices _crewsServices;
        private readonly IStateServices _stateServices;
        private readonly ICityServices _cityServices;
        private readonly ICountryServices _countryServices;

        public EmployeesController(IAccountServices accountServices, ICrewsServices crewsServices,
                                   IEmployeeServices employeeServices, IStateServices stateServices,
                                   ICityServices cityServices, ICountryServices countryServices)
        {
            _accountServices = accountServices;
            _crewsServices = crewsServices;
            _employeeServices = employeeServices;
            _stateServices = stateServices;
            _cityServices = cityServices;
            _countryServices = countryServices;
        }


        // GET: Admin/Employees
        public IActionResult Index()
        {
            return View(_accountServices.GetList().ToList());
        }

        // GET: Admin/Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _accountServices.GetList().FirstOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Admin/Employees/Create
        public IActionResult Create()
        {
            ViewBag.bloodList = _employeeServices.GetddlBoold();
            ViewBag.CrewsList = _crewsServices.GetddlCrews().ToList();
            ViewBag.CountryList = _countryServices.GetCountryList();
            return View();
        }

        //POST: Admin/Employees/Create 
        //To protect from overposting attacks, enable the specific properties you want to bind to, for  
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModelEmployee modelEmployee)
        {

            if (ModelState.IsValid)
            {


                var result = await _accountServices.CreateUserAsync(modelEmployee);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View();
                }

                ModelState.Clear();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Load State (country wise)
        [HttpGet]
        public JsonResult GetStateByCountryId(int countryId)
        {
            var StateData = _stateServices.GetStatesByCountryId(countryId).Select(m => new SelectListItem()
            {
                Value = m.Id.ToString(),
                Text = m.Name.ToString()
            });

            return new JsonResult(StateData);
        }

        //Load Cit (State wise)
        [HttpGet]
        public JsonResult GetCityByStateId(int stateId)
        {
            return new JsonResult(_cityServices.GetCityList(stateId).Select(m => new SelectListItem()
            {
                Value = m.Id.ToString(),
                Text = m.Name.ToString()
            }));
        }
    }
}
