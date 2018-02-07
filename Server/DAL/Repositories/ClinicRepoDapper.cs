using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ClinicRepoDapper : IRepository<Clinic>
    {
        private readonly string connectionString = null;

        public ClinicRepoDapper(string conn)
        {
            connectionString = conn;
        }

        public Task<int> Create(Clinic item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Clinic>> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Clinic>("sp_GetAllClinics").ToList();
            }
        }

        public Task<Clinic> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Clinic item)
        {
            throw new NotImplementedException();
        }
    }
}
