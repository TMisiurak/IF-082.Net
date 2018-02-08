using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using Moq;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class UserServiceTests
    {
        private readonly List<User> users = new List<User>
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

        private readonly List<UserDTO> usersDTO = new List<UserDTO>
        {
            new UserDTO{ Id = 1, Email = "email1@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                RoleId = 1, FullName = "Full Name 1", Address = "Address 1", BirthDay = new DateTime(1995, 1, 1),
                PhoneNumber = "0123456781", Sex = "mal", Image = "imagesrc 1" },
            new UserDTO{ Id = 2, Email = "email2@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                RoleId = 2, FullName = "Full Name 2", Address = "Address 2", BirthDay = new DateTime(1995, 2, 2),
                PhoneNumber = "0123456782", Sex = "fem", Image = "imagesrc 2" },
            new UserDTO{ Id = 3, Email = "email3@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                RoleId = 3, FullName = "Full Name 3", Address = "Address 3", BirthDay = new DateTime(1995, 3, 3),
                PhoneNumber = "0123456783", Sex = "fem", Image = "imagesrc 3" },
            new UserDTO{ Id = 4, Email = "email4@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                RoleId = 4, FullName = "Full Name 4", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
                PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 4" },
        };
        
        [Fact]
        public async void GetAll_Type_Test()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mockMapper = new Mock<IMapper>();

            unitOfWorkMock.Setup(m => m.Users.GetAll()).Returns(async () => {
                await Task.Yield();
                return users;
            });
            mockMapper.Setup(x => x.Map<List<UserDTO>>(It.IsAny<List<User>>())).Returns(usersDTO);

            var userService = new UserService(unitOfWorkMock.Object, mockMapper.Object);

            var getAll = await userService.GetAll();

            Assert.NotNull(getAll);
            Assert.Equal(users.Count, getAll.Count);
        }

        [Fact]
        public async void GetById_NotNull_Test()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mockMapper = new Mock<IMapper>();

            unitOfWorkMock.Setup(m => m.Users.GetById(It.IsAny<int>())).Returns<int>(async k =>
            {
                await Task.Yield();
                return users.Where(s => s.Id == k).FirstOrDefault();
            });
            mockMapper.Setup(x => x.Map<UserDTO>(It.Is<User>(k => k != null))).Returns<User>(x => usersDTO.Where(s => s.Id == x.Id).FirstOrDefault());
            mockMapper.Setup(x => x.Map<UserDTO>(null)).Returns(() => null);

            var userService = new UserService(unitOfWorkMock.Object, mockMapper.Object);

            var user1 = await userService.GetById(2);
            var user2 = await userService.GetById(5);

            Assert.NotNull(user1);
            Assert.Null(user2);
            Assert.Equal(2, user1.Id);
        }
    }
}
