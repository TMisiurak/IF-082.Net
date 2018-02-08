using DAL.EF;
using DAL.Interfaces;
using ProjectCore.Entities;

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
        private PrescriptionRepository prescriptionRepository;
        private DrugRepository drugRepository;
        private PatientRepository patientRepository;
        private PaymentRepository paymentRepository;

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
                return (IRepository<Drug>)drugRepository;
            }
        }

        public IRepository<Patient> Patients
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

    }
    }
