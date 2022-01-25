﻿using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using CorePoint.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorePoint.Service.Repostity
{
    public class StateServices : IStateServices
    {
        private readonly ApplicationContext _context;
        public StateServices(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<ViewModelState> GetList()
        {
            return _context.States.Select(s => new ViewModelState
            {
                Id = s.Id,
                Name = s.Name,
                CountryId=s.CountryId,
                CountryName = _context.Countries.Where(x => x.Id == s.CountryId).FirstOrDefault().Name
            }).ToList();
        }

        public ViewModelState GetDetailsById(int? id)
        {
            return GetList().FirstOrDefault(m => m.Id == id);
        }

        public void CreateState(State state)
        {
            _context.Add(state);
            _context.SaveChanges();
        }

        public void EditCountry(State state)
        {
            _context.Update(state);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var state = _context.States.Find(id);
            _context.States.Remove(state);
            _context.SaveChanges();
        }

        public bool StateExists(int id)
        {
            return _context.States.Any(e => e.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}