using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Role> Roles { get; }
        IUserRepository Users { get; }
        IRepository<Clinic> Clinics { get; }
        IRepository<Department> Departments { get; }
        IRepository<Procedure> Procedures { get; }
        IRepository<Diagnosis> Diagnoses { get; }

        void Save();
    }
}
