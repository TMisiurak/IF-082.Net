using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    class PrescriptionListDTOProfile : Profile
    {
        public PrescriptionListDTOProfile()
        {
            CreateMap<PrescriptionList, PrescriptionListDTO>();
            CreateMap<PrescriptionListDTO, PrescriptionList>();
        }
    }
}
