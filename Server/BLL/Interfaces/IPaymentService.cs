using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<IList<PaymentDTO>> GetAll();
        Task<PaymentDTO> GetById(int id);
        Task<int> Create(PaymentDTO item);
        Task<int> Update(PaymentDTO item);
        Task<int> DeleteById(int id);
    }
}
