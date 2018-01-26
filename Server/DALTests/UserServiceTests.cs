using DAL.EF;
using DAL.Entities;
using DAL.Repositories;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DALTests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetAll()
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

            var mock = new Mock<ClinicContext>();
            mock.Setup(x => users).Returns(users);

            var userRepo = new UserRepository(mock.Object);

            var usersGeted = userRepo.GetAll();
  
            Assert.Equal(users, usersGeted.Result);
        }
    }
}
