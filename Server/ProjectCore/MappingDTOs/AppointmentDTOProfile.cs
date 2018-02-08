using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class AppointmentDTOProfile: Profile
    {
        public AppointmentDTOProfile()
        {
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();
        }
    }
}
