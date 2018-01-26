using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Clinic> Clinics { get; }
        IUserRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        void Save();
    }
}
