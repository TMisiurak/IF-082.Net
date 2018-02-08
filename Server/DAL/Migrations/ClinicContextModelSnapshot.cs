﻿// <auto-generated />
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DAL.Migrations
{
    [DbContext(typeof(ClinicContext))]
    partial class ClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectCore.Entities.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("ProjectCore.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ProjectCore.Entities.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DiagnosisName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("ProjectCore.Entities.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DrugName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("ProjectCore.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ProjectCore.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PatientId");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<string>("PaymentType")
                        .IsRequired();

                    b.Property<int>("PrescriptionId");

                    b.Property<int>("sum");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("PrescriptionId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ProjectCore.Entities.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.Property<int>("DiagnosisId");

                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("ProjectCore.Entities.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Room");

                    b.HasKey("Id");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("ProjectCore.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProjectCore.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ProjectCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Email")
                        .HasName("AlternateKey_Email");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectCore.Entities.Department", b =>
                {
                    b.HasOne("ProjectCore.Entities.Clinic", "Clinic")
                        .WithMany("Departments")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectCore.Entities.Patient", b =>
                {
                    b.HasOne("ProjectCore.Entities.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("ProjectCore.Entities.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectCore.Entities.Payment", b =>
                {
                    b.HasOne("ProjectCore.Entities.Patient", "Patient")
                        .WithMany("Payment")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectCore.Entities.Prescription", "Prescription")
                        .WithOne("Payment")
                        .HasForeignKey("ProjectCore.Entities.Payment", "PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectCore.Entities.Prescription", b =>
                {
                    b.HasOne("ProjectCore.Entities.Diagnosis", "Diagnosis")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectCore.Entities.User", b =>
                {
                    b.HasOne("ProjectCore.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
