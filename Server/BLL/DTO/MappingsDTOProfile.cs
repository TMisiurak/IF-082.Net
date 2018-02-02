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
            CreateMap<Procedure, ProcedureDTO>();
            CreateMap<ProcedureDTO, Procedure>();
            CreateMap<Procedure, ProcedureDTO>();
            CreateMap<ProcedureDTO, Procedure>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
            

            CreateMap<Diagnosis, DiagnosisDTO>();
            CreateMap<DiagnosisDTO, Diagnosis>();
            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();
            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<PrescriptionDTO, Prescription>();
        }
    }
}
