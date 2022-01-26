using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorePoint.Service.Repostity
{
    public class CrewsServices : ICrewsServices
    {
        private readonly ApplicationContext _context;
        public CrewsServices(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ViewModelCrews> GetList()
        {
            return _context.Crews.Select(s => new ViewModelCrews
            {
                ID = s.ID,
                Name = s.Name,
                Code = s.Code,
                Sitecode = s.Sitecode,
                CreateBy = s.CreateBy,
                CreateDate = s.CreateDate,
                UpdateBy = s.UpdateBy,
                UpdateDate = s.UpdateDate
            }).ToList();
        }

        public ViewModelCrews GetDetailsById(int? id)
        {
            return GetList().FirstOrDefault(m => m.ID == id);
        }

        public void CreateCrew(Crew crew)
        {
            _context.Add(crew);
            _context.SaveChanges();
        }

        public void EditCrew(Crew crew)
        {
            _context.Update(crew);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            Crew crew = _context.Crews.Find(id);
            _context.Crews.Remove(crew);
            _context.SaveChanges();
        }

        public bool CrewExists(int id)
        {
            return _context.Crews.Any(e => e.ID == id);
        }

        public IEnumerable<ViewModelCrews> GetddlCrews()
        {
            return _context.Crews.Select(s => new ViewModelCrews
            {
                ID = s.ID,
                Name = s.Name
            });
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
