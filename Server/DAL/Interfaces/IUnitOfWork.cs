using ProjectCore.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Role> Roles { get; }
        IUserRepository Users { get; }
        IRepository<Clinic> Clinics { get; }
        IRepository<Department> Departments { get; }
        IRepository<Procedure> Procedures { get; }
        IRepository<Diagnosis> Diagnoses { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Prescription> Prescriptions { get; }
        IRepository<Drug> Drugs { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Payment> Payments { get; }
        IRepository<Appointment> Appointments { get; }
    }
}
