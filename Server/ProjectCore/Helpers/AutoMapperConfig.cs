using AutoMapper;
using ProjectCore.MappingDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Helpers
{
    public static class AutoMapperConfig
    {
        private static IMapper _instance;

        public static IMapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    CreateAutoMapper();
                }
                return _instance;
            }
        }

        public static void CreateAutoMapper()
        {
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<ClinicDTOProfile>();
                config.AddProfile<RoleDTOProfile>();
                config.AddProfile<DrugDTOProfile>();
                config.AddProfile<PrescriptionDTOProfile>();
                config.AddProfile<UserDTOProfile>();
                config.AddProfile<ProcedureDTOProfile>();
                config.AddProfile<DiagnosisDTOProfile>();
                config.AddProfile<DepartmentDTOProfile>();
                config.AddProfile<RoomDTOProfile>();
                config.AddProfile<PatientDTOProfile>();
                config.AddProfile<PaymentDTOProfile>();
                config.AddProfile<DoctorDTOProfile>();
                config.AddProfile<AppointmentDTOProfile>();
            });

            _instance = autoMapperConfig.CreateMapper();
        }
    }
}
