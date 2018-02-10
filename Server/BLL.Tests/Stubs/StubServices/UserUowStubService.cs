using BLL.Tests.Stubs.StubData;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests.Stubs.StubServices
{
    public static class UserUowStubService
    {
        private static List<User> _users = UserUowStubData.Users;

        public static async Task<IList<User>> GetAll()
        {
            await Task.Yield();
            return _users;
        }

        public static async Task<User> GetById(int id)
        {
            await Task.Yield();
            var user = _users.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }
    }
}
