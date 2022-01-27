using CorePoint.DAL.Data;
using CorePoint.DAL.Models;
using CorePoint.Service.Interfaces;
using System;

namespace CorePoint.Service.Repostity
{
    public class AddressServices : IAddressServices
    {
        private readonly ApplicationContext _context;
        public AddressServices(ApplicationContext context)
        {
            _context = context;
        }
        public int CreateAddress(Address address)
        {
            _context.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
