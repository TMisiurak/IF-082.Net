using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PaymentRepository : IRepository<Payment>
    {
        private readonly ClinicContext _db;

        public PaymentRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<int> Create(Payment payment)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = sp_CreatePayment @PatientId = {payment.PatientId}, @PaymentDate = '{payment.PaymentDate.ToString("yyyy-MM-dd")}', @PaymentType = '{payment.PaymentType}', @PrescriptionId = {payment.PrescriptionId}, @Sum = {payment.sum}";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<IList<Payment>> GetAll()
        {
            return await _db.Payments.FromSql("sp_GetAllPayments").ToListAsync();
        }

        public async Task<int> Delete(int id)
        {
            var param = new SqlParameter
            {
                ParameterName = "@resid",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @resid = dbo.sp_DeletePayment @id = {id}";

            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<Payment> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Payment payment = await _db.Payments.FromSql($"sp_GetPaymentById @id", param).FirstOrDefaultAsync();
            return payment;
        }

        public async Task<int> Update(Payment payment)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
           // string sql = $"exec @UpdateCounter = sp_CreatePayment @PatientId = {payment.PatientId}, @PaymentType = '{payment.PaymentType}', @PrescriptionId = {payment.PrescriptionId}, @sum = {payment.sum}, @Id = {payment.Id}";
           string sql = $"exec @UpdateCounter = sp_UpdatePayment @PatientId = {payment.PatientId}, @PaymentDate = '{payment.PaymentDate.ToString("yyyy-MM-dd")}', @PaymentType = '{payment.PaymentType}', @PrescriptionId = {payment.PrescriptionId}, @sum = {payment.sum}, @Id = {payment.Id}";

            //string sql = $"exec @UpdateCounter = dbo.sp_UpdatePatient @UserId = {patient.UserId},  @Id = {patient.Id}";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}
