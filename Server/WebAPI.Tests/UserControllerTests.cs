using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPI.Tests
{
    public class UserControllerTests
    {
        //[Fact]
        //public void GetById()
        //{
        //    var users = new List<UserDTO>
        //    {
        //        new UserDTO{ Id = 1, Email = "email1@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
        //            RoleId = 1, FullName = "Full Name 1", Address = "Address 1", BirthDay = new DateTime(1995, 1, 1),
        //            PhoneNumber = "0123456781", Sex = "mal", Image = "imagesrc 1" },
        //        new UserDTO{ Id = 2, Email = "email2@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
        //            RoleId = 2, FullName = "Full Name 2", Address = "Address 2", BirthDay = new DateTime(1995, 2, 2),
        //            PhoneNumber = "0123456782", Sex = "fem", Image = "imagesrc 2" },
        //        new UserDTO{ Id = 3, Email = "email3@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
        //            RoleId = 3, FullName = "Full Name 3", Address = "Address 3", BirthDay = new DateTime(1995, 3, 3),
        //            PhoneNumber = "0123456783", Sex = "fem", Image = "imagesrc 3" },
        //        new UserDTO{ Id = 4, Email = "email4@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
        //            RoleId = 4, FullName = "Full Name 4", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
        //            PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 4" },
        //    };

        //    int index = 1;

        //    var userService = new Mock<IUserService>();
        //    userService.Setup(m => m.GetById(index)).Returns(null as Task<UserDTO>
        //    );

        //    var userController = new UserController(userService.Object);

        //    var user = userController.GetUserById(index);

        //    var v = Assert.IsType<Task<IActionResult>>(user);
        //    //var z = v.Result;
            
        //    Assert.NotNull(user);
        //    //Assert.Equal(1, user.Id);
        //}
    }
}
