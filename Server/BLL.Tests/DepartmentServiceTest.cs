using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using Moq;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class  DepartmentServiceTest
        {
            private async Task<List<Department>> GetTestDepartments()
            {
                var departments = new List<Department>
                {
                    new Department {Name = "Diagnostic", ClinicId=1},
                    new Department {Name = "Cardiac", ClinicId=1},
                    new Department {Name = "Pediatric", ClinicId =1},
                    new Department {Name = "Ophtalmology", ClinicId=1}

                };
            
            await Task.Yield();
                return departments;
            }
            [Fact]
            public void GetAll()
            {
                var depRepo = new Mock<IRepository<Department>>();
                depRepo.Setup(x => x.GetAll()).Returns(GetTestDepartments());

                var unitOfWorkMock = new Mock<IUnitOfWork>();
                unitOfWorkMock.Setup(m => m.Departments).Returns(depRepo.Object);

                var mockMapper = new Mock<IMapper>();

                IService<DepartmentDTO> depService = new DepartmentService(unitOfWorkMock.Object, mockMapper.Object);
                var getAll = depService.GetAll();

                Assert.NotNull(getAll);
                var viewResult = Assert.IsType<Task<List<DepartmentDTO>>>(getAll);
                var model = Assert.IsAssignableFrom<Task<List<Department>>>(mockMapper.Object.Map<Task<List<Department>>>(getAll));
            }

            [Fact]
            public void GetDepartmentById()
            {
               
                var departments = new List<Department>
                {
                    new Department {Name = "Diagnostic", ClinicId=1},
                    new Department {Name = "Cardiac", ClinicId=1},
                    new Department {Name = "Pediatric", ClinicId =1},
                    new Department {Name = "Ophtalmology", ClinicId=1}

                };
                var depRepo = new Mock<IRepository<Department>>();
                depRepo.Setup(m => m.GetById(1)).Returns(async () =>
                {
                    await Task.Yield();
                    return departments.Where(x => x.Id == 1).FirstOrDefault();
                });

                var unitOfWorkMock = new Mock<IUnitOfWork>();
                unitOfWorkMock.Setup(m => m.Departments).Returns(depRepo.Object);

                var mockMapper = new Mock<IMapper>();
                mockMapper.Setup(x => x.Map<DepartmentDTO>(It.IsAny<Department>()))
                    .Returns(new DepartmentDTO());

                IService<DepartmentDTO> depService = new DepartmentService(unitOfWorkMock.Object, mockMapper.Object);
                var dep = depService.GetById(1);

                Assert.NotNull(dep);
                Assert.Equal(1, dep.Id);
            }
        }
    }

