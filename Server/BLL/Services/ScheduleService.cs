using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using ProjectCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public ScheduleService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<IList<ScheduleDTO>> GetAll()
        {
            IList<Schedule> schedules = await DataBase.Schedules.GetAll();
            IList<ScheduleDTO> result = _mapper.Map<IList<ScheduleDTO>>(schedules);
            return result;
        }

        public async Task<ScheduleDTO> GetById(int id)
        {
            Schedule schedule = await DataBase.Schedules.GetById(id);
            ScheduleDTO result = _mapper.Map<ScheduleDTO>(schedule);
            return result;
        }

        public async Task<IList<ScheduleAppointmentDTO>> GetByDoctorId(int id)
        {
            IList<Appointment> appointments = await DataBase.Appointments.GetByDoctorId(id);
            IList<Schedule> schedule = await DataBase.Schedules.GetByDoctorId(id);

            var s = new List<ScheduleAppointmentDTO>();

            var x = DateTime.Now.Date;

            for (int i = 0; i < schedule.FirstOrDefault().ValidityPeriod; i++)
            {
                var k = schedule.Where(l => l.Weekday == (int)x.DayOfWeek).FirstOrDefault();
                var a = appointments.Where(m => m.Date.Day == x.Day);
                if (k != null)
                {
                    x = x.Add(k.WorkStart);
                    for (int j = 1; j < k.TimeSlotCount + 1; j++)
                    {
                        s.Add(new ScheduleAppointmentDTO { TimeSlot = x, IsRegistered = false });
                        if (a != null && a.Where(aj => aj.Date == s.LastOrDefault().TimeSlot).FirstOrDefault() != null)
                        {
                            s.LastOrDefault().IsRegistered = true;
                        }
                        x = x.AddMinutes(k.SlotDuration);
                    }
                }
                x = DateTime.Now.Date;
                x = x.AddDays(i + 1);
            }

            return s;
        }

        public async Task<int> Create(ScheduleDTO scheduleDTO)
        {
            int result = await DataBase.Schedules.Create(_mapper.Map<Schedule>(scheduleDTO));
            return result;
        }

        public async Task<int> Update(ScheduleDTO scheduleDTO)
        {
            int result = await DataBase.Schedules.Update(_mapper.Map<Schedule>(scheduleDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Schedules.Delete(id);
            return result;
        }
    }
}
