using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class PrescriptionDTOProfile : Profile
    {
        public PrescriptionDTOProfile()
        {
            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<PrescriptionDTO, Prescription>();
        }
    }
}
