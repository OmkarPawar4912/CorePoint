using CorePoint.DAL.Models;
using System;

namespace CorePoint.Service.Interfaces
{
    public interface IAddressServices : IDisposable
    {
        int CreateAddress(Address address);
    }
}