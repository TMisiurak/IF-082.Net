using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Clinic> Clinics { get; }
        UserRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        void Save();
    }
}
