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
    [Migration("20180203214809_newinit")]
    partial class newinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Clinic", b =>
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

            modelBuilder.Entity("DAL.Entities.Department", b =>
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

            modelBuilder.Entity("DAL.Entities.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DiagnosisName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Diagnosis");
                });

            modelBuilder.Entity("DAL.Entities.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DrugName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("DAL.Entities.Prescription", b =>
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

            modelBuilder.Entity("DAL.Entities.Procedure", b =>
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

            modelBuilder.Entity("DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DAL.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
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

            modelBuilder.Entity("DAL.Entities.Department", b =>
                {
                    b.HasOne("DAL.Entities.Clinic", "Clinic")
                        .WithMany("Departments")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Entities.Prescription", b =>
                {
                    b.HasOne("DAL.Entities.Diagnosis", "Diagnosis")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.HasOne("DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
