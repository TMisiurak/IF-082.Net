using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class DrugServiceTest
    {
        private async Task<List<Drug>> GetTestDrugs()
        {
            var drugs = new List<Drug>
            {
                new Drug { Id=1, DrugName = "TestDrug1"},
                new Drug { Id=2, DrugName = "TestDrug2"},
                new Drug { Id=3, DrugName = "TestDrug3"},
                new Drug { Id=4, DrugName = "TestDrug4"},
                new Drug { Id=4, DrugName = "TestDrug5"},
            };
            await Task.Yield();
            return drugs;
        }
        [Fact]
        public void GetAll()
        {

            var drugRepo = new Mock<IRepository<Drug>>();
            drugRepo.Setup(x => x.GetAll()).Returns(GetTestDrugs());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Drugs).Returns(drugRepo.Object);

            var mockMapper = new Mock<IMapper>();

            IService<DrugDTO> drugService = new DrugService(unitOfWorkMock.Object, mockMapper.Object);
            var getAll = drugService.GetAll();

            Assert.NotNull(getAll);
            var viewResult = Assert.IsType<Task<List<DrugDTO>>>(getAll);
            var model = Assert.IsAssignableFrom<Task<List<Drug>>>(mockMapper.Object.Map<Task<List<Drug>>>(getAll));
        }

        [Fact]
        public void GetDrugById()
        {
            var drugs = new List<Drug>
            {
                new Drug { Id=1, DrugName = "TestDrug1"},
                new Drug { Id=2, DrugName = "TestDrug2"},
                new Drug { Id=3, DrugName = "TestDrug3"},
                new Drug { Id=4, DrugName = "TestDrug4"},
                new Drug { Id=4, DrugName = "TestDrug5"},
            };

            var drugRepo = new Mock<IRepository<Drug>>();
            drugRepo.Setup(m => m.GetById(1)).Returns(async () =>
            {
                await Task.Yield();
                return drugs.Where(x => x.Id == 1).FirstOrDefault();
            });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Drugs).Returns(drugRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<DrugDTO>(It.IsAny<Drug>()))
                .Returns(new DrugDTO());

            IService<DrugDTO> drugService = new DrugService(unitOfWorkMock.Object, mockMapper.Object);
            var drug = drugService.GetById(1);

            Assert.NotNull(drug);
            Assert.Equal(1, drug.Id);
        }
    }
}
