using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class PaymentDTOProfile : Profile
    {
        public PaymentDTOProfile()
        {
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
        }
    }
}
