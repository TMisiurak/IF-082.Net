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

namespace DAL.Tests
{
    public class RoleServiceTests
    {
        private async Task<IList<Role>> GetTestRoles()
        {
            var roles = new List<Role>
            {
                new Role { Id=1, Name = "TestRole1"},
                new Role { Id=2, Name = "TestRole2"},
                new Role { Id=3, Name = "TestRole3"},
                new Role { Id=4, Name = "TestRole4"},
            };
            await Task.Yield();
            return roles;
        }
        [Fact]
        public void GetAll()
        {
            var roleRepo = new Mock<IRepository<Role>>();
            roleRepo.Setup(x => x.GetAll()).Returns(GetTestRoles());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Roles).Returns(roleRepo.Object);

            var mockMapper = new Mock<IMapper>();

            IRoleService<RoleDTO> roleService = new RoleService(unitOfWorkMock.Object, mockMapper.Object);
            var getAll = roleService.GetAll();

            Assert.NotNull(getAll);
            var viewResult = Assert.IsType<Task<List<RoleDTO>>>(getAll);
            var model = Assert.IsAssignableFrom<Task<List<Role>>>(mockMapper.Object.Map<Task<List<Role>>>(getAll));
        }

        [Fact]
        public void GetRoleById()
        {
            var roles = new List<Role>
            {
                new Role { Id=1, Name = "TestRole1"},
                new Role { Id=2, Name = "TestRole2"},
                new Role { Id=3, Name = "TestRole3"},
                new Role { Id=4, Name = "TestRole4"},
            };

            var roleRepo = new Mock<IRepository<Role>>();
            roleRepo.Setup(m => m.GetById(2)).Returns(async () =>
            {
                await Task.Yield();
                return roles.Where(x => x.Id == 2).FirstOrDefault();
            });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Roles).Returns(roleRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<RoleDTO>(It.IsAny<Role>()))
                .Returns(new RoleDTO());

            IRoleService<RoleDTO> roleService = new RoleService(unitOfWorkMock.Object, mockMapper.Object);
            var role = roleService.GetById(2);

            Assert.NotNull(role);
            Assert.Equal(2, role.Id);
        }
    }
}
