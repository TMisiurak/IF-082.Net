using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class PaymentRepoDapper : IRepository<Payment>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public PaymentRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(Payment payment)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PatientId", payment.PatientId);
            dynamicParameters.Add("@PaymentDate", payment.PaymentDate.ToString("yyyy-MM-dd"));
            dynamicParameters.Add("@PaymentType", payment.PaymentType);
            dynamicParameters.Add("@PrescriptionId", payment.PrescriptionId);
            dynamicParameters.Add("@Sum", payment.sum);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_CreatePayment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeletePayment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Payment>> GetAll()
        {
            var result = await _connection.QueryAsync<Payment>("sp_GetAllPayments", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Payment> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<Payment>("sp_GetPaymentById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Payment payment)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PatientId", payment.PatientId);
            dynamicParameters.Add("@PaymentDate", payment.PaymentDate.ToString("yyyy-MM-dd"));
            dynamicParameters.Add("@PaymentType", payment.PaymentType);
            dynamicParameters.Add("@PrescriptionId", payment.PrescriptionId);
            dynamicParameters.Add("@Sum", payment.sum);
            dynamicParameters.Add("@Id", payment.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_UpdatePayment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }
    }
}
