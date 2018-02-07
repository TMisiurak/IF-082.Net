using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class DepartmentDTOProfile : Profile
    {
        public DepartmentDTOProfile()
        {
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
        }
    }
}
