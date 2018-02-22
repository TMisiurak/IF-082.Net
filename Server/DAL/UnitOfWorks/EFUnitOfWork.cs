using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories.EFRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectCore.Entities;
using System;

namespace DAL.UnitOfWorks
{

    public class EFUnitOfWork : IUnitOfWork
    {
        private ClinicContext db;
        private IDbContextTransaction _transaction;

        private RoleRepository roleRepository;
        private UserRepository userRepository;
        private ClinicRepository clinicRepository;
        private DepartmentRepository departmentRepository;
        private ProcedureRepository procedureRepository;
        private DiagnosisRepository diagnosisRepository;
        private RoomRepository roomRepository;
        private PrescriptionRepository prescriptionRepository;
        private DrugRepository drugRepository;
        private PatientRepository patientRepository;
        private PaymentRepository paymentRepository;
        private AppointmentRepository appointmentRepository;
        private DoctorRepository doctorRepository;
        private PrescriptionListRepository prescriptionListRepository;
        private ScheduleRepository scheduleRepository;

        public EFUnitOfWork(ClinicContext context)
        {
            db = context;
            _transaction = db.Database.BeginTransaction();
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

        public IRepository<Prescription> Prescriptions
        {
            get
            {
                if (prescriptionRepository == null)
                    prescriptionRepository = new PrescriptionRepository(db);
                return prescriptionRepository;
            }
        }

        public IRepository<Drug> Drugs
        {
            get
            {
                if (drugRepository == null)
                    drugRepository = new DrugRepository(db);
                return drugRepository;
            }
        }

        public IPatientRepository Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(db);
                return patientRepository;
            }
        }

        public IRepository<Payment> Payments
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(db);
                return paymentRepository;
            }
        }
        
        public IAppointmentRepository Appointments
        {
            get
            {
                if (appointmentRepository == null)
                    appointmentRepository = new AppointmentRepository(db);
                return appointmentRepository;
            }
        }

        public IDoctorRepository Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(db);
                return doctorRepository;
            }
        }

        public IRepository<PrescriptionList> PrescriptionLists
        {
            get
            {
                if (prescriptionListRepository == null)
                    prescriptionListRepository = new PrescriptionListRepository(db);
                return prescriptionListRepository;
            }
        }

        public IScheduleRepository Schedules
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                //throw;
            }
            finally
            {
                _transaction.Dispose();
            }
        }
    }
}
