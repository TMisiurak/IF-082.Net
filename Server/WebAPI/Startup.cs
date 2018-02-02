using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Swagger;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IService<RoleDTO>, RoleService>();
            services.AddTransient<IService<DepartmentDTO>, DepartmentService>();
            services.AddTransient<IService<PrescriptionDTO>, PrescriptionService>();
            services.AddTransient<IService<ProcedureDTO>, ProcedureService>();
            services.AddTransient<IService<DiagnosisDTO>, DiagnosisService>();
            services.AddTransient<IService<RoomDTO>, RoomService>();


            services.AddAutoMapper();

            services.AddDbContext<ClinicContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.OperationFilter<AddRequiredHeaderParameter>();
            });

            services.AddMvc();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1";
                });

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:5003")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //InitializeDatabase(app);
            }
            app.UseCors("default");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            app.UseMvc();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                List<Clinic> clinics = new List<Clinic>
                {
                    new Clinic{ Name = "CDC", Address = "Mazepy 114a, Ivano-Frankivsk" },
                    new Clinic{ Name = "Regional Hospital", Address = "Fedkovych 91, Ivano-Frankivsk" },
                    new Clinic{ Name = "Children's Hospital", Address = "Konovaltcia 132, Ivano-Frankivsk" },
                };

                List<Department> departments = new List<Department>
                {
                    new Department {Name = "Diagnostic", ClinicId=1},
                    new Department {Name = "Cardiac", ClinicId=1},
                    new Department {Name = "Pediatric", ClinicId =1},
                    new Department {Name = "Ophtalmology", ClinicId=1}

                };

                List<Role> roles = new List<Role>
                {
                    new Role{ Name="admin" },
                    new Role{ Name="patient" },
                    new Role{ Name="doctor" },
                    new Role{ Name="accountant" },
                };

                List<User> users = new List<User>
                {
                    // password is "pass"
                    new User{ Email = "email1@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                        RoleId = 1, FullName = "Full Name 1", Address = "Address 1", BirthDay = new DateTime(1995, 1, 1),
                        PhoneNumber = "0123456781", Sex = "mal", Image = "imagesrc 1" },
                    new User{ Email = "email2@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                        RoleId = 2, FullName = "Full Name 2", Address = "Address 2", BirthDay = new DateTime(1995, 2, 2),
                        PhoneNumber = "0123456782", Sex = "fem", Image = "imagesrc 2" },
                    new User{ Email = "email3@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                        RoleId = 3, FullName = "Full Name 3", Address = "Address 3", BirthDay = new DateTime(1995, 3, 3),
                        PhoneNumber = "0123456783", Sex = "fem", Image = "imagesrc 3" },
                    new User{ Email = "email4@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                        RoleId = 4, FullName = "Full Name 4", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
                        PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 4" },
                };

                List<Drug> drugs = new List<Drug>
                {
                    new Drug{ DrugName="Aspirin" },
                    new Drug{ DrugName="Lidokain" },
                    new Drug{ DrugName="Dimedrol" },
                    new Drug{ DrugName="Validol" },
                    new Drug{ DrugName="Urolesan" },
                    new Drug{ DrugName="Mesim Forte" },
                    new Drug{ DrugName="Allergomaks" },
                    new Drug{ DrugName="Skinoren" },
                    new Drug{ DrugName="Clotrimazole" },
                    new Drug{ DrugName="Ketanol" },
                };

                List<Room> rooms = new List<Room>
                {
                    new Room { Name = "Reception", Number = 1 },
                    new Room { Name = "Doctor Name Here", Number = 10 },
                    new Room { Name = "Intense Therapy", Number = 15 },
                    new Room { Name = "X-Ray", Number = 17 },
                    new Room { Name = "Diagnostics Room", Number = 50 }
                };

                List<Diagnosis> diagnosis = new List<Diagnosis>
                {
                    new Diagnosis{ DiagnoseName="Migren", Description = "easy" },
                    new Diagnosis{ DiagnoseName="Kashel", Description = "middle" },
                    new Diagnosis{ DiagnoseName="GRZ", Description = "easy" },
                };

                List<Prescription> prescriptions = new List<Prescription>
                {
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tablets",
                    Date = DateTime.Now, DiagnosisId = 1},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tea",
                    Date = DateTime.Now, DiagnosisId = 2},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "nimesil",
                    Date = DateTime.Now, DiagnosisId = 3},
                };

                List<Procedure> procedures = new List<Procedure>
                {
                    new Procedure{Name = "V/Q Scan", Price = 2500.50M, Room = 101 },
                    new Procedure{Name = "VSclerotherapy", Price = 1500.50M, Room = 25 },
                    new Procedure{Name = "Sperm Banking", Price = 500.50M, Room = 141 },
                    new Procedure{Name = "Oral Wellness", Price = 200.50M, Room = 99 },
                    new Procedure{Name = "Electrical Cardioversion", Price = 100.50M, Room = 12 },
                };

                var context = serviceScope.ServiceProvider.GetRequiredService<ClinicContext>();
                context.Database.Migrate();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(roles);
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(users);
                    context.SaveChanges();
                }

                if (!context.Clinics.Any())
                {
                    context.Clinics.AddRange(clinics);
                    context.SaveChanges();
                }

                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(departments);
                    context.SaveChanges();
                }

                if (!context.Drugs.Any())
                {
                    context.Drugs.AddRange(drugs);
                    context.SaveChanges();
                }

                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(rooms);
                    context.SaveChanges();
                }

                if (!context.Diagnoses.Any())
                {
                    context.Diagnoses.AddRange(diagnosis);
                    context.SaveChanges();
                }

                if (!context.Prescriptions.Any())
                {
                    context.Prescriptions.AddRange(prescriptions);
                    context.SaveChanges();
                }

                if (!context.Procedures.Any())
                {
                    context.Procedures.AddRange(procedures);
                    context.SaveChanges();
                }
            }
        }
    }
}
