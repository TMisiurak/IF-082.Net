using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class DrugDTOProfile : Profile
    {
        public DrugDTOProfile()
        {
            CreateMap<Drug, DrugDTO>();
            CreateMap<DrugDTO, Drug>();
        }
    }
}
