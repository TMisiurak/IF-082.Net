using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace ProjectCore.MappingDTOs
{
    public class ScheduleDTOProfile : Profile
    {
        public ScheduleDTOProfile()
        {
            CreateMap<Schedule, ScheduleDTO>();
            CreateMap<ScheduleDTO, Schedule>();
        }
    }
}
