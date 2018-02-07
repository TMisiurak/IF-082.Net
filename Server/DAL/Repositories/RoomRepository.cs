using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoomRepository : IRepository<Room> 
    {
        private readonly ClinicContext _db;

        public RoomRepository(ClinicContext context)
        {
            _db = context;
        }

        public async Task<int> Create(Room room)
        {
            string sql = $"sp_CreateRoom @Name = '{room.Name}', @Number = '{room.Number}'";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var param = new SqlParameter
            {
                ParameterName = "@resid",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @resid = dbo.sp_DeleteRoom @id = {id}";

            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<List<Room>> GetAll()
        {
            return await _db.Rooms.FromSql("sp_GetAllRooms").ToListAsync();
        }

        public async Task<Room> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Room room = await _db.Rooms.FromSql($"sp_GetRoomById @id", param).FirstOrDefaultAsync();

            return room;
        }

        public Task<int> Update(Room item)
        {
            throw new NotImplementedException();
        }
    }
}
