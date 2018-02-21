using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.EFRepositories
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        private readonly ClinicContext _db;

        public ScheduleRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<IList<Schedule>> GetAll()
        {
            return await _db.Schedules.FromSql("sp_GetAllSchedules").ToListAsync();
        }

        public async Task<Schedule> GetById(int id)
        {
            var param = new SqlParameter("@DoctorId", id);
            var param1 = new SqlParameter("@Id", id);
            var x = await _db.Schedules.FromSql($"sp_GetScheduleByDoctorId @DoctorId", param).ToListAsync();
            var y = await _db.Appointments.FromSql($"sp_GetAppointmentById @Id", param1).ToListAsync();
            var result = x.Join(y, xs => xs.Weekday, ys => (int)ys.Date.DayOfWeek, (xs, ys) => new { A = xs.SlotDuration, B = xs.Weekday });
            foreach (var i in result)
            {
                System.Console.WriteLine("{0} - {1}", i.A, i.B);
            }

            //return user;
            return new Schedule();
        }

        public async Task<int> Create(Schedule schedule)
        {
            var createdId = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = dbo.sp_CreateSchedule @WorkStart = '{schedule.WorkStart}', @TimeSlotCount = '{schedule.TimeSlotCount}', @SlotDuration = '{schedule.SlotDuration}', @BreakStart = '{schedule.BreakStart}', @BreakDuration = '{schedule.BreakDuration}', @Weekday = '{schedule.Weekday}', @ValidityPeriod = '{schedule.ValidityPeriod}', @DoctorId = '{schedule.DoctorId}'";
            await _db.Database.ExecuteSqlCommandAsync(sql, createdId);
            return (int)createdId.Value;
        }

        public async Task<int> Update(Schedule schedule)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateCounter = dbo.sp_UpdateSchedule @Id = {schedule.Id}, @WorkStart = '{schedule.WorkStart}', @TimeSlotCount = '{schedule.TimeSlotCount}', @SlotDuration = '{schedule.SlotDuration}', @BreakStart = '{schedule.BreakStart}', @BreakDuration = '{schedule.BreakDuration}', @Weekday = '{schedule.Weekday}', @ValidityPeriod = '{schedule.ValidityPeriod}', @DoctorId = '{schedule.DoctorId}'";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }

        public async Task<int> Delete(int id)
        {
            var delCounter = new SqlParameter
            {
                ParameterName = "@DelCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @DelCounter = dbo.sp_DeleteSchedule @Id = {id}";            
            await _db.Database.ExecuteSqlCommandAsync(sql, delCounter);
            return (int)delCounter.Value;
        }
    }
}
