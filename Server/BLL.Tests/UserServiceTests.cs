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
    public class UserServiceTests
    {
        private async Task<List<User>> GetTestUsers()
        {
            var users = new List<User>
            {
                new User{ Id = 1, Email = "email1@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 1, FullName = "Full Name 1", Address = "Address 1", BirthDay = new DateTime(1995, 1, 1),
                    PhoneNumber = "0123456781", Sex = "mal", Image = "imagesrc 1" },
                new User{ Id = 2, Email = "email2@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 2, FullName = "Full Name 2", Address = "Address 2", BirthDay = new DateTime(1995, 2, 2),
                    PhoneNumber = "0123456782", Sex = "fem", Image = "imagesrc 2" },
                new User{ Id = 3, Email = "email3@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 3, FullName = "Full Name 3", Address = "Address 3", BirthDay = new DateTime(1995, 3, 3),
                    PhoneNumber = "0123456783", Sex = "fem", Image = "imagesrc 3" },
                new User{ Id = 4, Email = "email4@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 4, FullName = "Full Name 4", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
                    PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 4" },
            };
            await Task.Yield();
            return users;
        }
        [Fact]
        public void GetAll_Type_Test()
        {
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.GetAll()).Returns(GetTestUsers());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Users).Returns(userRepo.Object);

            var mockMapper = new Mock<IMapper>();

            mockMapper.Object.Map<List<UserDTO>>(It.IsAny<List<User>>());

            IUserService userService = new UserService(unitOfWorkMock.Object, mockMapper.Object);
            var getAll = userService.GetAll();

            Assert.NotNull(getAll);
            var viewResult = Assert.IsType<Task<List<UserDTO>>>(getAll);
            var model = Assert.IsAssignableFrom<Task<List<User>>>(mockMapper.Object.Map<Task<List<User>>>(getAll));
        }

        [Fact]
        public void GetById_NotNull_Test()
        {
            var users = new List<User>
            {
                new User{ Id = 1, Email = "email1@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 1, FullName = "Full Name 1", Address = "Address 1", BirthDay = new DateTime(1995, 1, 1),
                    PhoneNumber = "0123456781", Sex = "mal", Image = "imagesrc 1" },
                new User{ Id = 2, Email = "email2@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 2, FullName = "Full Name 2", Address = "Address 2", BirthDay = new DateTime(1995, 2, 2),
                    PhoneNumber = "0123456782", Sex = "fem", Image = "imagesrc 2" },
                new User{ Id = 3, Email = "email3@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 3, FullName = "Full Name 3", Address = "Address 3", BirthDay = new DateTime(1995, 3, 3),
                    PhoneNumber = "0123456783", Sex = "fem", Image = "imagesrc 3" },
                new User{ Id = 4, Email = "email4@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                    RoleId = 4, FullName = "Full Name 4", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
                    PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 4" },
            };

            int index = 1;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Users.GetById(index)).Returns(async () =>
            {
                await Task.Yield();
                return users.Where(x => x.Id == index).FirstOrDefault();
            });

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<UserDTO>(It.IsAny<User>())).Returns(new UserDTO());

            var userService = new UserService(unitOfWorkMock.Object, mockMapper.Object);

            var user = userService.GetById(index);

            Assert.NotNull(user);
            //Assert.Equal(1, user.Id);
        }
    }
}
