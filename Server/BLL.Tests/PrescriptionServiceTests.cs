using AutoMapper;
using BLL.Services;
using BLL.Tests.Stubs.StubData;
using BLL.Tests.Stubs.StubServices;
using DAL.Interfaces;
using Moq;
using ProjectCore.Helpers;
using System;
using System.Threading.Tasks;
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

        [Fact]
        //[Fact(Skip = "reason")]
        public async Task TestGetAllPrescriptions()
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

        [Fact]
        public void TestGetPrescriptionById()
        {
            // Arrange
            _uow.Setup(p => p.Prescriptions.GetById(It.IsAny<int>())).Returns<int>(async (id) =>
                await PrescriptionUowStubService.GetById(id));

            // var unitOfWorkMock = new Mock<IUnitOfWork>();
            // unitOfWorkMock.Setup(m => m.Prescriptions).Returns(prescriptionRepo.Object);

            //  var mockMapper = new Mock<IMapper>();
            //  mockMapper.Setup(x => x.Map<PrescriptionDTO>(It.IsAny<Prescription>()))
            //      .Returns(new PrescriptionDTO());

            //  IPrescriptionService prescriptionService = new PrescriptionService(unitOfWorkMock.Object, mockMapper.Object);

            // Act
            var getPrescription1 = _prescriptionService.GetById(101);
            var getPrescription2 = _prescriptionService.GetById(102);
            var getPrescription3 = _prescriptionService.GetById(105);

            // Assert
            Assert.NotNull(getPrescription1.Result);
            Assert.NotNull(getPrescription2.Result);
            Assert.Null(getPrescription3.Result);

            Assert.Equal(101, getPrescription1.Result.Id);
            Assert.Equal(102, getPrescription2.Result.Id);
            //Assert.Equal(3, getPrescription3.Id);
        }
    }
}
