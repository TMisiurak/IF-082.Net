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
    public class PrescriptionListServiceTests
    {
        private Mock<IUnitOfWork> _uow;
        private PrescriptionListService _prescriptionListService;

        public PrescriptionListServiceTests()
        {
            IMapper mapper = AutoMapperConfig.Instance;
            _uow = new Mock<IUnitOfWork>();

            _prescriptionListService = new PrescriptionListService(_uow.Object, mapper);
        }

        [Fact]
        public async Task TestGetAllPrescriptionLists()
        {
            // Arrange
            _uow.Setup(p => p.PrescriptionLists.GetAll()).Returns(async () =>
                await PrescriptionListUowStubService.GetAll());

            // Act
            var getAllPrescriptionLists = await _prescriptionListService.GetAll();

            // Assert
            Assert.NotNull(getAllPrescriptionLists);
            Assert.Equal(PrescriptionListUowStubData.PrescriptionLists.Count, getAllPrescriptionLists.Count);
        }

        [Fact]
        public void TestGetPrescriptionListById()
        {
            // Arrange
            _uow.Setup(p => p.PrescriptionLists.GetById(It.IsAny<int>())).Returns<int>(async (id) =>
                await PrescriptionListUowStubService.GetById(id));

            // Act
            var getPrescriptionList1 = _prescriptionListService.GetById(201);
            var getPrescriptionList2 = _prescriptionListService.GetById(205);
            var getPrescriptionList3 = _prescriptionListService.GetById(206);

            // Assert
            Assert.NotNull(getPrescriptionList1.Result);
            Assert.NotNull(getPrescriptionList2.Result);
            Assert.Null(getPrescriptionList3.Result);

            Assert.Equal(201, getPrescriptionList1.Result.Id);
            Assert.Equal(205, getPrescriptionList2.Result.Id);
        }
    }
}
