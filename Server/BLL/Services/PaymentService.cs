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
        IUnitOfWork _unitOfWork { get; set; }
        IMapper _mapper;

        public PaymentService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(PaymentDTO paymentDTO)
        {
            int result = await _unitOfWork.Payments.Create(_mapper.Map<Payment>(paymentDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Payments.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<PaymentDTO>> GetAll()
        {
            IEnumerable<Payment> payments = await _unitOfWork.Payments.GetAll();
            return _mapper.Map<List<PaymentDTO>>(payments);
        }
        ///
        public async Task<PaymentDTO> GetById(int id)
        {
            Payment payment = await _unitOfWork.Payments.GetById(id);
            PaymentDTO result = _mapper.Map<PaymentDTO>(payment);
            return result;
        }

        public async Task<int> Update(PaymentDTO paymentDTO)
        {
            int result = await _unitOfWork.Payments.Update(_mapper.Map<Payment>(paymentDTO));
            _unitOfWork.Commit();
            return result;
        }
    }
}
