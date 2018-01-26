using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
        T Get(string email);
    }
}
