using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectCore.Helpers;
using WebAPI.Controllers;
using Xunit;

namespace WebAPI.Tests
{
    public class PrescriptionListControllerTests
    {
        private Mock<IPrescriptionListService> _prescriptionListService;
        private PrescriptionListController _prescriptionListController;

        public PrescriptionListControllerTests()
        {
            var mapper = AutoMapperConfig.Instance;
            _prescriptionListService = new Mock<IPrescriptionListService>();
            _prescriptionListController = new PrescriptionListController(mapper, _prescriptionListService.Object);
        }

        // LaunchGetAll
        [Fact]
        public async Task TestGetPrescriptionLists()
        {

            await _prescriptionListController.GetPrescriptionLists();
            _prescriptionListService.Verify(p => p.GetAll(), Times.Once);
        }
    }
}
