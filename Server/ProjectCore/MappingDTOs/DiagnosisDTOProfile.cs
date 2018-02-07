using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class DiagnosisDTOProfile : Profile
    {
        public DiagnosisDTOProfile()
        {
            CreateMap<Diagnosis, DiagnosisDTO>();
            CreateMap<DiagnosisDTO, Diagnosis>();
        }
    }
}
