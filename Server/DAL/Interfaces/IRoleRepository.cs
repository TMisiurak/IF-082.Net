using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByName(string name);
    }
}
