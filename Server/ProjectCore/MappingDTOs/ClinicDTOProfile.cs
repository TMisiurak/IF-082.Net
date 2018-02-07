using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class ClinicDTOProfile : Profile
    {
        public ClinicDTOProfile()
        {
            CreateMap<Clinic, ClinicDTO>();
            CreateMap<ClinicDTO, Clinic>();
        }
    }
}
