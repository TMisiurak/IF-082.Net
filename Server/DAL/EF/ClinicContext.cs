﻿using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;

namespace DAL.EF
{
    public class ClinicContext : DbContext
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PrescriptionList> PrescriptionLists { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasAlternateKey(c => c.Email)
              .HasName("AlternateKey_Email");
        }
    }
}
