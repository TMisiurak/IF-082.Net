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
        private UserRepoDapper _userRepository;
        private RoleRepoDapper _roleRepository;
        private DepartmentRepoDapper _departmentRepository;
        private ProcedureRepoDapper _procedureRepository;
        private DiagnosisRepoDapper _diagnosisRepository;
        private RoomRepoDapper _roomRepository;
        private PrescriptionRepoDapper _prescriptionRepository;
        private PrescriptionListRepoDapper _prescriptionListRepository;
        private DrugRepoDapper _drugRepository;
        private PatientRepoDapper _patientRepository;
        private PaymentRepoDapper _paymentRepository;
        private AppointmentRepoDapper _appointmentRepository;
        private DoctorRepoDapper _doctorRepository;
        private ScheduleRepoDapper _scheduleRepository;

        public DapperUnitOfWork(SqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IRepository<Clinic> Clinics
        {
            get { return _clinicRepository ?? (_clinicRepository = new ClinicRepoDapper(_transaction)); }
        }

        public IRoleRepository Roles
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepoDapper(_transaction)); }
        }

        public IUserRepository Users
        {
            get { return _userRepository ?? (_userRepository = new UserRepoDapper(_transaction)); }
        }

        public IRepository<Department> Departments
        {
            get { return _departmentRepository ?? (_departmentRepository = new DepartmentRepoDapper(_transaction)); }
        }

        public IRepository<Procedure> Procedures
        {
            get { return _procedureRepository ?? (_procedureRepository = new ProcedureRepoDapper(_transaction)); }
        }

        public IRepository<Diagnosis> Diagnoses
        {
            get { return _diagnosisRepository ?? (_diagnosisRepository = new DiagnosisRepoDapper(_transaction)); }
        }

        public IRepository<Room> Rooms
        {
            get { return _roomRepository ?? (_roomRepository = new RoomRepoDapper(_transaction)); }
        }

        public IRepository<Prescription> Prescriptions
        {
            get { return _prescriptionRepository ?? (_prescriptionRepository = new PrescriptionRepoDapper(_transaction)); }
        }

        public IRepository<PrescriptionList> PrescriptionLists
        {
            get { return _prescriptionListRepository ?? (_prescriptionListRepository = new PrescriptionListRepoDapper(_transaction)); }
        }

        public IRepository<Drug> Drugs
        {
            get { return _drugRepository ?? (_drugRepository = new DrugRepoDapper(_transaction)); }
        }

        public IPatientRepository Patients
        {
            get { return _patientRepository ?? (_patientRepository = new PatientRepoDapper(_transaction)); }
        }

        public IRepository<Payment> Payments
        {
            get { return _paymentRepository ?? (_paymentRepository = new PaymentRepoDapper(_transaction)); }
        }

        public IAppointmentRepository Appointments
        {
            get { return _appointmentRepository ?? (_appointmentRepository = new AppointmentRepoDapper(_transaction)); }
        }

        public IRepository<Doctor> Doctors
        {
            get { return _doctorRepository ?? (_doctorRepository = new DoctorRepoDapper(_transaction)); }
        }

        public IScheduleRepository Schedules
        {
            get { return _scheduleRepository ?? (_scheduleRepository = new ScheduleRepoDapper(_transaction)); }
        }

        IDoctorRepository IUnitOfWork.Doctors => throw new NotImplementedException();

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
