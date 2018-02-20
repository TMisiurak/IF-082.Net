using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Interfaces;
using DAL.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectCore.Entities;
using ProjectCore.Helpers;
using ProjectCore.MappingDTOs;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            services.AddScoped<IUnitOfWork>(provider =>
            {
                if (Configuration["MyORM"] == "EF")
                {
                    return new EFUnitOfWork(new ClinicContext(Configuration.GetConnectionString("DefaultConnection")));
                }
                else
                {
                    return new DapperUnitOfWork(new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));
                }
            });
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IPrescriptionService, PrescriptionService>();
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IProcedureService, ProcedureService>();
            services.AddTransient<IDiagnosisService, DiagnosisService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPrescriptionListService, PrescriptionListService>();
            services.AddTransient<IScheduleService, ScheduleService>();

            services.AddSingleton(s => AutoMapperConfig.Instance);
            
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
                    policy.WithOrigins("http://localhost:4200")
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

                    new User{ Email = "email5@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                        RoleId = 3, FullName = "Full Name 5", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
                        PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 5" },
                    new User{ Email = "email6@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                        RoleId = 3, FullName = "Full Name 6", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
                        PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 6" },
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

                List<Diagnosis> diagnoses = new List<Diagnosis>
                {
                    new Diagnosis{ DiagnosisName="Migren", Description = "easy" },
                    new Diagnosis{ DiagnosisName="Kashel", Description = "middle" },
                    new Diagnosis{ DiagnosisName="GRZ", Description = "easy" },
                };

                List<Prescription> prescriptions = new List<Prescription>
                {
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tablets",
                    Date = DateTime.Now, DiagnosisId = 1},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tea",
                    Date = DateTime.Now, DiagnosisId = 2},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "nimesil",
                    Date = DateTime.Now, DiagnosisId = 3},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "analgin",
                    Date = DateTime.Now, DiagnosisId = 1},
                };

                List<Doctor> doctors = new List<Doctor>
                {
                    new Doctor{ YearsExp = 1, Speciality = "Surgeon", RoomId = 1, DepartmentId = 1, UserId = 5 },
                    new Doctor{ YearsExp = 2, Speciality = "Oculist", RoomId = 2, DepartmentId = 2, UserId = 6 },
                };

                List<Procedure> procedures = new List<Procedure>
                {
                    new Procedure{Name = "V/Q Scan", Price = 2500.50M, Room = 101 },
                    new Procedure{Name = "VSclerotherapy", Price = 1500.50M, Room = 25 },
                    new Procedure{Name = "Sperm Banking", Price = 500.50M, Room = 141 },
                    new Procedure{Name = "Oral Wellness", Price = 200.50M, Room = 99 },
                    new Procedure{Name = "Electrical Cardioversion", Price = 100.50M, Room = 12 },
                };

                List<Patient> patients = new List<Patient>
                {
                    new Patient {UserId=2 },
                    new Patient {UserId=1 },
                };


                List<Payment> payments = new List<Payment>
                {
                    new Payment { PatientId=1, PaymentDate= DateTime.Now, PaymentType="cash ok", PrescriptionId=1, sum= 250},
                    new Payment { PatientId=2, PaymentDate= DateTime.Now, PaymentType="cash ok", PrescriptionId=2, sum= 250}
                    
                };

                List<Appointment> appointments = new List<Appointment>
                {
                    new Appointment { Date=DateTime.Now, Description="appointment details 1", DoctorId=1, PatientId=2, Status=1 },
                    new Appointment { Date=DateTime.Now, Description="appointment details 2", DoctorId=2, PatientId=2, Status=2 },
                    new Appointment { Date=DateTime.Now, Description="appointment details 3", DoctorId=2, PatientId=2, Status=3 },
                    new Appointment { Date=DateTime.Now, Description="appointment details 4", DoctorId=1, PatientId=2, Status=4 }
                };

                List<PrescriptionList> prescriptionLists = new List<PrescriptionList>
                {
                    new PrescriptionList { ProcedureId = 1, DrugId = 1, PrescriptionId = 1},
                    new PrescriptionList { ProcedureId = 2, DrugId = 3, PrescriptionId = 2},
                    new PrescriptionList { ProcedureId = 3, DrugId = 4, PrescriptionId = 3},
                    new PrescriptionList { ProcedureId = 4, DrugId = 5, PrescriptionId = 1},
                    new PrescriptionList { ProcedureId = 5, DrugId = 2, PrescriptionId = 2},
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
                    context.Diagnoses.AddRange(diagnoses);
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

                if (!context.Patients.Any())
                {
                    context.Patients.AddRange(patients);
                    context.SaveChanges();
                }

                if (!context.Payments.Any())
                {
                    context.Payments.AddRange(payments);
                    context.SaveChanges();
                }

                if (!context.Doctors.Any())
                {
                    context.Doctors.AddRange(doctors);
                    context.SaveChanges();
                }

                if (!context.Appointments.Any())
                {
                    context.Appointments.AddRange(appointments);
                    context.SaveChanges();
                }

                if (!context.PrescriptionLists.Any())
                {
                    context.PrescriptionLists.AddRange(prescriptionLists);
                    context.SaveChanges();
                }
            }
        }
    }
}
