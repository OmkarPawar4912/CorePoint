using CorePoint.DAL.Data;
using CorePoint.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CorePoint.Service.Repostity
{
    public class AdminServices : IAdminServices
    {
        private readonly ApplicationContext _context;
        public AdminServices(ApplicationContext context)
        {
            _context = context;
        }

        public List<int> AdminDashboradCount()
        {
            var data = _context.Employees.ToList();
            var countList = new List<int>
            {
                data.Count(),
                data.Where(x => x.IsSupervisior ==true).Count(),
                data.Where(x => x.IsSupervisior ==false).Count()
            };
            return countList;
        }
    }
}
