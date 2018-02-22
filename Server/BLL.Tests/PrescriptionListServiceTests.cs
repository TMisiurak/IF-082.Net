using AutoMapper;
using BLL.Services;
using BLL.Tests.Stubs.StubData;
using BLL.Tests.Stubs.StubServices;
using DAL.Interfaces;
using Moq;
using ProjectCore.Helpers;
using System;
using System.Threading.Tasks;
using System.Transactions;
using ProjectCore.DTO;
using ProjectCore.Entities;
using Xunit;

namespace BLL.Tests
{
    public class PrescriptionListServiceTests
    {
        private Mock<IUnitOfWork> _uow;
        private PrescriptionListService _prescriptionListService;
        private TransactionScope trans = null;

        public PrescriptionListServiceTests()
        {
            IMapper mapper = AutoMapperConfig.Instance;
            _uow = new Mock<IUnitOfWork>();

            _prescriptionListService = new PrescriptionListService(_uow.Object, mapper);
        }

        // GetAll
        [Fact]
        public async Task Test1GetAllPrescriptionLists()
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

        // GetById
        [Fact]
        public async Task Test2GetPrescriptionListById()
        {
            // Arrange
            _uow.Setup(p => p.PrescriptionLists.GetById(It.IsAny<int>())).Returns<int>(async (id) =>
                await PrescriptionListUowStubService.GetById(id));

            // Act
            var getPrescriptionList1 = await _prescriptionListService.GetById(201);
            var getPrescriptionList2 = await _prescriptionListService.GetById(204);
            var getPrescriptionList3 = await _prescriptionListService.GetById(208);

            // Assert
            Assert.NotNull(getPrescriptionList1);
            Assert.NotNull(getPrescriptionList2);
            Assert.Null(getPrescriptionList3);

            Assert.Equal(201, getPrescriptionList1.Id);
            Assert.Equal(204, getPrescriptionList2.Id);
        }

        // Update
        [Fact]
        public async Task Test3UpdatePrescriptionList()
        {
            // Arrange
            _uow.Setup(p => p.PrescriptionLists.Update(It.IsAny<PrescriptionList>()))
                .Returns<PrescriptionList>(async (pl) =>
                await PrescriptionListUowStubService.Update(pl));

            // Act
            var indexPrescriptionList = await _prescriptionListService
                .Update(new PrescriptionListDTO { Id = 202, ProcedureId = 3, DrugId = 4, PrescriptionId = 1 });
  
            // Assert
            Assert.Equal(5, PrescriptionListUowStubData.PrescriptionLists.Count);
            Assert.Equal(1, indexPrescriptionList);
            Assert.Equal(202, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList].Id);
            Assert.Equal(3, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList].ProcedureId);
            Assert.Equal(4, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList].DrugId);
            Assert.Equal(1, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList].PrescriptionId); 
        }

        // Create
        [Fact]
        public async Task Test4CreatePrescriptionList()
        {
            // Arrange
            _uow.Setup(p => p.PrescriptionLists.Create(It.IsAny<PrescriptionList>()))
                .Returns<PrescriptionList>(async (pl) =>
                    await PrescriptionListUowStubService.Create(pl));

            // Act
            var indexPrescriptionList1 = await _prescriptionListService
                .Create(new PrescriptionListDTO { Id = 206, ProcedureId = 1, DrugId = 1, PrescriptionId = 1 });
            //var indexPrescriptionList2 = _prescriptionListService
            //   .Create(new PrescriptionListDTO { Id = 207, ProcedureId = 2, DrugId = 2, PrescriptionId = 2 });

            // Assert
            Assert.Equal(6, indexPrescriptionList1);
            //Assert.Equal(7, indexPrescriptionList2.Result);
            Assert.Equal(206, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList1 - 1].Id);
            Assert.Equal(1, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList1 - 1].ProcedureId);
            Assert.Equal(1, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList1 - 1].DrugId);
            Assert.Equal(1, PrescriptionListUowStubData.PrescriptionLists[indexPrescriptionList1 - 1].PrescriptionId);
        }
        
        // DeleteById
        [Fact]
        public async Task Test5DeletePrescriptionListById()
        {
            // Arrange
            _uow.Setup(p => p.PrescriptionLists.Delete(It.IsAny<int>())).Returns<int>(async (id) =>
                await PrescriptionListUowStubService.DeleteById(id));

            // Act
            var indexPrescriptionList1 = await _prescriptionListService.DeleteById(206);
            //var indexPrescriptionList2 = _prescriptionListService.DeleteById(207);

            // Assert
            Assert.Equal(5, indexPrescriptionList1);
            Assert.Equal(5, PrescriptionListUowStubData.PrescriptionLists.Count);
        }
    }
}
