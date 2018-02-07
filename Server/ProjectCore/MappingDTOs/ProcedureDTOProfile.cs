using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class ProcedureDTOProfile : Profile
    {
        public ProcedureDTOProfile()
        {
            CreateMap<Procedure, ProcedureDTO>();
            CreateMap<ProcedureDTO, Procedure>();
        }
    }
}
