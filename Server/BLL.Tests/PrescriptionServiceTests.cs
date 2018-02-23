using AutoMapper;
using BLL.Services;
using BLL.Tests.Stubs.StubData;
using BLL.Tests.Stubs.StubServices;
using DAL.Interfaces;
using Moq;
using ProjectCore.Helpers;
using System;
using System.Threading.Tasks;
using ProjectCore.DTO;
using ProjectCore.Entities;
using Xunit;

namespace BLL.Tests
{
    public class PrescriptionServiceTests
    {
        private Mock<IUnitOfWork> _uow;
        private PrescriptionService _prescriptionService;

        public PrescriptionServiceTests()
        {
            IMapper mapper = AutoMapperConfig.Instance;
            _uow = new Mock<IUnitOfWork>();

            _prescriptionService = new PrescriptionService(_uow.Object, mapper);
        }

        // GetAll
        [Fact]
        public async Task Test1GetAllPrescriptions()
        {
            // Arrange
            _uow.Setup(p => p.Prescriptions.GetAll()).Returns(async () =>
                await PrescriptionUowStubService.GetAll());

            // Act
            var getAllPrescriptions = await _prescriptionService.GetAll();

            // Assert
            Assert.NotNull(getAllPrescriptions);
            Assert.Equal(PrescriptionUowStubData.Prescriptions.Count, getAllPrescriptions.Count);
        }

        // GetById
        [Fact]
        public async Task Test2GetPrescriptionById()
        {
            // Arrange
            _uow.Setup(p => p.Prescriptions.GetById(It.IsAny<int>())).Returns<int>(async (id) =>
                await PrescriptionUowStubService.GetById(id));

            // Act
            var getPrescription1 = await _prescriptionService.GetById(101);
            var getPrescription2 = await _prescriptionService.GetById(102);
            var getPrescription3 = await _prescriptionService.GetById(105);

            // Assert
            Assert.NotNull(getPrescription1);
            Assert.NotNull(getPrescription2);
            Assert.Null(getPrescription3);

            Assert.Equal(101, getPrescription1.Id);
            Assert.Equal(102, getPrescription2.Id);
        }

        // Update
        [Fact]
        public async Task Test3UpdatePrescription()
        {
            // Arrange
            _uow.Setup(p => p.Prescriptions.Update(It.IsAny<Prescription>()))
                .Returns<Prescription>(async (presc) =>
                await PrescriptionUowStubService.Update(presc));

            // Act
            var indexPrescription = await _prescriptionService
                .Update(new PrescriptionDTO {
                    Id = 102,
                    DoctorId = 2,
                    PatientId = 1,
                    Description = "green tea",
                    Date = DateTime.Now,
                    DiagnosisId = 2
                });

            // Assert
            Assert.Equal(3, PrescriptionUowStubData.Prescriptions.Count);
            Assert.Equal(1, indexPrescription);
            Assert.Equal(102, PrescriptionUowStubData.Prescriptions[indexPrescription].Id);
            Assert.Equal(2, PrescriptionUowStubData.Prescriptions[indexPrescription].DoctorId);
            Assert.Equal("green tea", PrescriptionUowStubData.Prescriptions[indexPrescription].Description);
        }

        // Create
        [Fact]
        public async Task Test4CreatePrescription()
        {
            // Arrange
            _uow.Setup(p => p.Prescriptions.Create(It.IsAny<Prescription>()))
                .Returns<Prescription>(async (presc) =>
                    await PrescriptionUowStubService.Create(presc));

            // Act
            var indexPrescription = await _prescriptionService
                .Create(new PrescriptionDTO {
                    Id = 104,
                    DoctorId = 2,
                    PatientId = 3,
                    Description = "flukonazol",
                    Date = DateTime.Now,
                    DiagnosisId = 1
                });

            // Assert
            Assert.Equal(4, indexPrescription);
            Assert.Equal(104, PrescriptionUowStubData.Prescriptions[indexPrescription - 1].Id);
            Assert.Equal(2, PrescriptionUowStubData.Prescriptions[indexPrescription - 1].DoctorId);
            Assert.Equal("flukonazol", PrescriptionUowStubData.Prescriptions[indexPrescription - 1].Description);
        }

        // DeleteById
        [Fact]
        public async Task Test5DeletePrescriptionById()
        {
            // Arrange
            _uow.Setup(p => p.Prescriptions.Delete(It.IsAny<int>())).Returns<int>(async (id) =>
                await PrescriptionUowStubService.DeleteById(id));

            // Act
            var indexPrescription = await _prescriptionService.DeleteById(104);

            // Assert
            Assert.Equal(3, indexPrescription);
            Assert.Equal(3, PrescriptionUowStubData.Prescriptions.Count);
        }
    }
}
