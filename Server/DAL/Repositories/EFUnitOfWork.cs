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
        private UserRepository userRepository;
        private ClinicRepository clinicRepository;
        private DepartmentRepository departmentRepository;
        private ProcedureRepository procedureRepository;
        private DiagnosisRepository diagnosisRepository;
        private RoomRepository roomRepository;

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

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
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

        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(db);
                return departmentRepository;
            }
        }

        public IRepository<Procedure> Procedures
        {
            get
            {
                if (procedureRepository == null)
                    procedureRepository = new ProcedureRepository(db);
                return procedureRepository;
            }
        }

        public IRepository<Diagnosis> Diagnoses
        {
            get
            {
                if (diagnosisRepository == null)
                    diagnosisRepository = new DiagnosisRepository(db);
                return diagnosisRepository;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new RoomRepository(db);
                return roomRepository;
            }
        }
    }
}
