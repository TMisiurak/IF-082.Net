using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class PrescriptionServiceTests
    {
        private async Task<List<Prescription>> GetTestPrescriptions()
        {
            var testPrescriptions = new List<Prescription>
                {
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tablets",
                    Date = DateTime.Now, DiagnosisId = 1},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tea",
                    Date = DateTime.Now, DiagnosisId = 2},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "nimesil",
                    Date = DateTime.Now, DiagnosisId = 3},
                };
            return await Task.Run(() => testPrescriptions);
        }

        [Fact]
        //[Fact(Skip = "reason")]
        public void Test_methodGetAllPrescriptions()
        {
            // Arrange
            var prescriptionRepo = new Mock<PrescriptionRepository>();
            prescriptionRepo.Setup(x => x.GetAll()).Returns(GetTestPrescriptions());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Prescriptions).Returns(prescriptionRepo.Object);

            var mockMapper = new Mock<IMapper>();
            //mockMapper.Setup(x => x.Map<ClinicDTO>(It.IsAny<Prescription>())).Returns(new PrescriptionDTO());
            //mockMapper.Object.Map<List<PrescriptionDTO>>(It.IsAny<List<Prescripiton>>());

            IService<PrescriptionDTO> prescriptionService = new PrescriptionService(unitOfWorkMock.Object, mockMapper.Object);

            // Act
            var getAllPrescriptions = prescriptionService.GetAll();

            // Assert
            Assert.NotNull(getAllPrescriptions);
            // Assert.Equal(3, Task.FromResult<IService<ClinicDTO>>(getAllClinics));
            // Assert.Equal(4, getAll.Result.Count);

            var viewResult = Assert.IsType<Task<List<PrescriptionDTO>>>(getAllPrescriptions);
            var model = Assert.IsAssignableFrom<Task<List<Prescription>>>(mockMapper.Object.Map<Task<List<User>>>(getAllPrescriptions));
        }

        [Fact]
        public void Test_methodGetByIdPrescriptions()
        {
            // Arrange
            var prescriptionRepo = new Mock<PrescriptionRepository>();
            prescriptionRepo.Setup(m => m.GetById(1)).Returns(async () =>
            {
                await Task.Yield();
                var testPrescriptions = GetTestPrescriptions();
                return testPrescriptions.Result.Where(x => x.Id == 1).FirstOrDefault(); 
            });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Prescriptions).Returns(prescriptionRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<PrescriptionDTO>(It.IsAny<Prescription>()))
                .Returns(new PrescriptionDTO());

            IService<PrescriptionDTO> prescriptionService = new PrescriptionService(unitOfWorkMock.Object, mockMapper.Object);

            // Act
            var getPrescription = prescriptionService.GetById(1);

            // Assert
            Assert.NotNull(getPrescription);
            Assert.Equal(1, getPrescription.Id);
        }
    }
}
