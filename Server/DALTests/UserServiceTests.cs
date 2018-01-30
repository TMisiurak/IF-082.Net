using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DALTests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetAll()
        {
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(m => m.GetAll()).Returns(GetAllUsers());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Users).Returns(userRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<UserDTO>(It.IsAny<User>()))
                .Returns(new UserDTO());

            IUserService userService = new UserService(unitOfWorkMock.Object, mockMapper.Object);
            var getAll = userService.GetAll();

            Assert.NotNull(getAll);
            //Assert.Equal(4, getAll.Result.Count);
        }

        [Fact]
        public void GetById()
        {
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(m => m.GetById(1)).Returns(GetUserById(1));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Users).Returns(userRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<UserDTO>(It.IsAny<User>()))
                .Returns(new UserDTO());

            IUserService userService = new UserService(unitOfWorkMock.Object, mockMapper.Object);
            var user = userService.GetById(1);

            Assert.NotNull(user);
            //Assert.Equal(1, getAll.Result.Count);
        }

        private async Task<List<User>> GetAllUsers()
        {
            var users = new List<User>
            {
                new User { Id=1, FullName="iPhone 7", Email="Apple1@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495291"},
                new User { Id=2, FullName="iPhone 8", Email="Apple2@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495292"},
                new User { Id=3, FullName="iPhone 9", Email="Apple3@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495293"},
                new User { Id=4, FullName="iPhone 10", Email="Apple4@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495297"},
            };
            return users;
        }

        private async Task<User> GetUserById(int id)
        {
            var users = new List<User>
            {
                new User { Id=1, FullName="iPhone 7", Email="Apple1@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495291"},
                new User { Id=2, FullName="iPhone 8", Email="Apple2@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495292"},
                new User { Id=3, FullName="iPhone 9", Email="Apple3@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495293"},
                new User { Id=4, FullName="iPhone 10", Email="Apple4@g.com", Address="street", BirthDay= new System.DateTime(2020-12-01),
                Image = "SRC", Password = "pass", RoleId= 1, PhoneNumber="0999495297"},
            };

            var result = users.Where(x => x.Id == id).FirstOrDefault();

            return result;
            //test
        }
    }
}
