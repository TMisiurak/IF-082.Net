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

namespace DAL.Tests
{
    public class ClinicServiceTests
    {
        private async Task<List<Clinic>> GetTestClinics()
        {
            var clinics = new List<Clinic>
            {
                new Clinic { Id=1, Name = "TestClinic1"},
                new Clinic { Id=2, Name = "TestClinic2"},
                new Clinic { Id=3, Name = "TestClinic3"},
                new Clinic { Id=4, Name = "TestClinic4"},
            };
            await Task.Yield();
            return clinics;
        }
        [Fact]
        public void GetAll()
        {
            var clinicRepo = new Mock<IRepository<Clinic>>();
            clinicRepo.Setup(x => x.GetAll()).Returns(GetTestClinics());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Clinics).Returns(clinicRepo.Object);

            var mockMapper = new Mock<IMapper>();

            IService<ClinicDTO> clinicService = new ClinicService(unitOfWorkMock.Object, mockMapper.Object);
            var getAll = clinicService.GetAll();

            Assert.NotNull(getAll);
            var viewResult = Assert.IsType<Task<List<ClinicDTO>>>(getAll);
            var model = Assert.IsAssignableFrom<Task<List<Clinic>>>(mockMapper.Object.Map<Task<List<Clinic>>>(getAll));
        }

        [Fact]
        public void GetClinicById()
        {
            var clinics = new List<Clinic>
            {
                new Clinic { Id=1, Name = "TestClinic1"},
                new Clinic { Id=2, Name = "TestClinic2"},
                new Clinic { Id=3, Name = "TestClinic3"},
                new Clinic { Id=4, Name = "TestClinic4"},
            };

            var clinicRepo = new Mock<IRepository<Clinic>>();
            clinicRepo.Setup(m => m.GetById(1)).Returns(async () =>
            {
                await Task.Yield();
                return clinics.Where(x => x.Id == 1).FirstOrDefault();
            });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Clinics).Returns(clinicRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<ClinicDTO>(It.IsAny<Clinic>()))
                .Returns(new ClinicDTO());

            IService<ClinicDTO> clinicService = new ClinicService(unitOfWorkMock.Object, mockMapper.Object);
            var clinic = clinicService.GetById(1);

            Assert.NotNull(clinic);
            Assert.Equal(1, clinic.Id);
        }
    }
}
