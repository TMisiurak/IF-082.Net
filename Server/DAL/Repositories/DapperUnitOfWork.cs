﻿using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private readonly string connectionString = null;

        private ClinicRepoDapper clinicRepository;

        public DapperUnitOfWork(string conn)
        {
            connectionString = conn;
        }

        public IRepository<Clinic> Clinics
        {
            get
            {
                if (clinicRepository == null)
                    clinicRepository = new ClinicRepoDapper(connectionString);
                return clinicRepository;
            }
        }

        public IRepository<Role> Roles => throw new NotImplementedException();

        public IUserRepository Users => throw new NotImplementedException();

        public IRepository<Department> Departments => throw new NotImplementedException();

        public IRepository<Procedure> Procedures => throw new NotImplementedException();

        public IRepository<Diagnosis> Diagnoses => throw new NotImplementedException();

        public IRepository<Room> Rooms => throw new NotImplementedException();

        public IRepository<Prescription> Prescriptions => throw new NotImplementedException();

        public IRepository<Drug> Drugs => throw new NotImplementedException();
    }
}
