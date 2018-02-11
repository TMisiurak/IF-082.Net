using DAL.Interfaces;
using DAL.Repositories.DapperRepositories;
using ProjectCore.Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.UnitOfWorks
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private ClinicRepoDapper _clinicRepository;

        public DapperUnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IRepository<Clinic> Clinics
        {
            get { return _clinicRepository ?? (_clinicRepository = new ClinicRepoDapper(_transaction)); }
        }

        public IRepository<Role> Roles => throw new NotImplementedException();

        public IUserRepository Users => throw new NotImplementedException();

        public IRepository<Department> Departments => throw new NotImplementedException();

        public IRepository<Procedure> Procedures => throw new NotImplementedException();

        public IRepository<Diagnosis> Diagnoses => throw new NotImplementedException();

        public IRepository<Room> Rooms => throw new NotImplementedException();

        public IRepository<Prescription> Prescriptions => throw new NotImplementedException();

        public IRepository<Drug> Drugs => throw new NotImplementedException();

        public IRepository<Patient> Patients => throw new NotImplementedException();

        public IRepository<Payment> Payments => throw new NotImplementedException();

        public IRepository<Appointment> Appointments => throw new NotImplementedException();

        public IRepository<Doctor> Doctors => throw new NotImplementedException();

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
            }
        }
    }
}
