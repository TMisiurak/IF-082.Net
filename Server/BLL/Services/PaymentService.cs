using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using ProjectCore;
using DAL.Interfaces;
using ProjectCore.Entities;
using ProjectCore.DTO;

namespace BLL.Services

{
    public class PaymentService : IPaymentService
    {
        IUnitOfWork Database { get; set; }
        IMapper _mapper;

        public PaymentService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(PaymentDTO paymentDTO)
        {
            int result = await Database.Payments.Create(_mapper.Map<Payment>(paymentDTO));
            Database.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await Database.Payments.Delete(id);
            Database.Commit();
            return result;
        }

        public async Task<IList<PaymentDTO>> GetAll()
        {
            IEnumerable<Payment> payments = await Database.Payments.GetAll();
            return _mapper.Map<List<PaymentDTO>>(payments);
        }
        ///
        public async Task<PaymentDTO> GetById(int id)
        {
            Payment payment = await Database.Payments.GetById(id);
            PaymentDTO result = _mapper.Map<PaymentDTO>(payment);
            return result;
        }

        public async Task<int> Update(PaymentDTO paymentDTO)
        {
            int result = await Database.Payments.Update(_mapper.Map<Payment>(paymentDTO));
            Database.Commit();
            return result;
        }
    }
}
