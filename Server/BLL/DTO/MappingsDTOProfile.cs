using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    public class MappingsDTOProfile : Profile
    {
        public MappingsDTOProfile()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Clinic, ClinicDTO>();
            CreateMap<ClinicDTO, Clinic>();
        }
    }
}
