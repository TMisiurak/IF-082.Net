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
    public class UserServiceTests
    {
        private Mock<IUnitOfWork> _uow;
        private UserService _userService;

        public UserServiceTests()
        {
            IMapper mapper = AutoMapperConfig.Instance;
            _uow = new Mock<IUnitOfWork>();

            _userService = new UserService(_uow.Object, mapper);
        }

        [Fact]
        public async Task GetAll_Equal_Test()
        {
            _uow.Setup(m => m.Users.GetAll()).Returns(async () => await UserUowStubService.GetAll());

            var getAll = await _userService.GetAll();

            Assert.NotNull(getAll);
            Assert.Equal(UserUowStubData.Users.Count, getAll.Count);
        }

        [Fact]
        public async Task GetById_NotNull_Test()
        {
            _uow.Setup(m => m.Users.GetById(It.IsAny<int>())).Returns<int>(async (id) => await UserUowStubService.GetById(id));

            var user1 = await _userService.GetById(2);
            var user2 = await _userService.GetById(5);

            Assert.NotNull(user1);
            Assert.Null(user2);
            Assert.Equal(2, user1.Id);
            Assert.Equal("email2@e.com", user1.Email);
        }
    }
}
