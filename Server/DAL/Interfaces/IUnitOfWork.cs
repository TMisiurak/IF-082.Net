﻿using ProjectCore.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IRepository<Clinic> Clinics { get; }
        IRepository<Department> Departments { get; }
        IRepository<Procedure> Procedures { get; }
        IRepository<Diagnosis> Diagnoses { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Prescription> Prescriptions { get; }
        IRepository<Drug> Drugs { get; }
        IPatientRepository Patients { get; }
        IRepository<Payment> Payments { get; }
        IAppointmentRepository Appointments { get; }
        IDoctorRepository Doctors { get; }
        IRepository<PrescriptionList> PrescriptionLists { get; }
        IScheduleRepository Schedules { get; }

        void Commit();
    }
}
