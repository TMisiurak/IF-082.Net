using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DALTests
{
    public class DepartmentServiceTests
    {
        [Fact]
        public void GetAll()
        {
            var depRepo = new Mock<IRepository<Department>>();
            depRepo.Setup(m => m.GetAll()).Returns(GetAllDepartments());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Departments).Returns(depRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<DepartmentDTO>(It.IsAny<Department>()))
                .Returns(new DepartmentDTO());

            IService<DepartmentDTO> depService = new DepartmentService(unitOfWorkMock.Object, mockMapper.Object);
            var getAll = depService.GetAll();

            

            Assert.NotNull(getAll);
            //Assert.Equal(0, getAll.Result.Count);
        }

        [Fact]
        public void GetById()
        {
            var depRepo = new Mock<IRepository<Department>>();
           depRepo.Setup(m => m.GetById(1)).Returns(GetDepartmentById(1));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Departments).Returns(depRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<DepartmentDTO>(It.IsAny<Department>()))
                .Returns(new DepartmentDTO());

            IService<DepartmentDTO> depService = new DepartmentService(unitOfWorkMock.Object, mockMapper.Object);
            var department = depService.GetById(1);

            Assert.NotNull(department);
            //Assert.Equal(1, getAll.Result.Count);
        }

        private async Task<List<Department>> GetAllDepartments()
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

        private async Task<Department> GetDepartmentById(int id)
        {
            var users = new List<Department>
            {
                new Department {Name = "Diagnostic", ClinicId=1},
                    new Department {Name = "Cardiac", ClinicId=1},
                    new Department {Name = "Pediatric", ClinicId =1},
                    new Department {Name = "Ophtalmology", ClinicId=1}
            };

            var result = users.Where(x => x.Id == id).FirstOrDefault();
            
            return result;
            
        }
    }
}
