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
    public class DiagnosisServiceTests
    {
        private async Task<List<Diagnosis>> GetTestDiagnosis()
        {
            var diagnoses = new List<Diagnosis>
            {
                new Diagnosis { Id=1, DiagnosisName = "TestDiagnosis1", Description = "TestDescription1" },
                new Diagnosis { Id=2, DiagnosisName = "TestDiagnosis2", Description = "TestDescription2" },
                new Diagnosis { Id=3, DiagnosisName = "TestDiagnosis3", Description = "TestDescription3" },
                new Diagnosis { Id=4, DiagnosisName = "TestDiagnosis4", Description = "TestDescription4" },
                new Diagnosis { Id=4, DiagnosisName = "TestDiagnosis5", Description = "TestDescription5" }
            };
            await Task.Yield();
            return diagnoses;
        }

        [Fact]
        public void GetAll()
        {
            var diagnosisRepo = new Mock<IRepository<Diagnosis>>();
            diagnosisRepo.Setup(x => x.GetAll()).Returns(GetTestDiagnosis());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Diagnoses).Returns(diagnosisRepo.Object);

            var mockMapper = new Mock<IMapper>();

            IService<DiagnosisDTO> diagnosisService = new DiagnosisService(unitOfWorkMock.Object, mockMapper.Object);
            var getAll = diagnosisService.GetAll();

            Assert.NotNull(getAll);
            var viewResult = Assert.IsType<Task<List<DiagnosisDTO>>>(getAll);
            var model = Assert.IsAssignableFrom<Task<List<Diagnosis>>>(mockMapper.Object.Map<Task<List<Diagnosis>>>(getAll));
        }

        [Fact]
        public void GetDiagnosisById()
        {
            var diagnoses = new List<Diagnosis>
            {
                new Diagnosis { Id=1, DiagnosisName = "TestDiagnosis1", Description = "TestDescription1" },
                new Diagnosis { Id=2, DiagnosisName = "TestDiagnosis2", Description = "TestDescription2" },
                new Diagnosis { Id=3, DiagnosisName = "TestDiagnosis3", Description = "TestDescription3" },
                new Diagnosis { Id=4, DiagnosisName = "TestDiagnosis4", Description = "TestDescription4" },
                new Diagnosis { Id=4, DiagnosisName = "TestDiagnosis5", Description = "TestDescription5" }
            };

            var diagnosisRepo = new Mock<IRepository<Diagnosis>>();
            diagnosisRepo.Setup(m => m.GetById(1)).Returns(async () =>
            {
                await Task.Yield();
                return diagnoses.Where(x => x.Id == 1).FirstOrDefault();
            });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Diagnoses).Returns(diagnosisRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<DiagnosisDTO>(It.IsAny<Diagnosis>()))
                .Returns(new DiagnosisDTO());

            IService<DiagnosisDTO> diagnosisService = new DiagnosisService(unitOfWorkMock.Object, mockMapper.Object);
            var diagnosis = diagnosisService.GetById(1);

            Assert.NotNull(diagnoses);
            Assert.Equal(1, diagnosis.Id);
        }
    }
}