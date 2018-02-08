using AutoMapper;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.MappingDTOs
{
    public class DoctorDTOProfile : Profile
    {
        public DoctorDTOProfile()
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
        }
    }
}
