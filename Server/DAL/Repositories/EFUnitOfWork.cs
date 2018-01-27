using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ClinicContext db;
        private RoleRepository roleRepository;
        private UserRepository<User> userRepository;
        private ClinicRepository clinicRepository;

        public EFUnitOfWork(ClinicContext context)
        {
            db = context;
        }
        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public UserRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository<User>(db);
                return userRepository;
            }
        }

        public IRepository<Clinic> Clinics
        {
            get
            {
                if (clinicRepository == null)
                    clinicRepository = new ClinicRepository(db);
                return clinicRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
