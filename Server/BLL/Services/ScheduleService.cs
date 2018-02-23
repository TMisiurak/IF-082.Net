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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScheduleService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<IList<ScheduleDTO>> GetAll()
        {
            IList<Schedule> schedules = await _unitOfWork.Schedules.GetAll();
            IList<ScheduleDTO> result = _mapper.Map<IList<ScheduleDTO>>(schedules);
            return result;
        }

        public async Task<ScheduleDTO> GetById(int id)
        {
            Schedule schedule = await _unitOfWork.Schedules.GetById(id);
            ScheduleDTO result = _mapper.Map<ScheduleDTO>(schedule);
            return result;
        }

        public async Task<IList<FreeTimeSlotsDTO>> GetByDoctorId(int id)
        {
            IList<Appointment> appointments = await _unitOfWork.Appointments.GetByDoctorId(id);
            IList<Schedule> schedule = await _unitOfWork.Schedules.GetByDoctorId(id);

            var freeTimeSlots = new List<FreeTimeSlotsDTO>();

            var currentDay = DateTime.Now.Date;

            for (int i = 0; i < schedule.FirstOrDefault().ValidityPeriod; i++)
            {
                var daySchedule = schedule.Where(ds => ds.Weekday == (int)currentDay.DayOfWeek).FirstOrDefault();
                var dayAppointments = appointments.Where(da => da.Date.Day == currentDay.Day);
                if (daySchedule != null)
                {
                    currentDay = currentDay.Add(daySchedule.WorkStart);
                    for (int j = 1; j < daySchedule.TimeSlotCount + 1; j++)
                    {
                        freeTimeSlots.Add(new FreeTimeSlotsDTO { TimeSlot = currentDay, IsRegistered = false });
                        if (dayAppointments != null && dayAppointments.Where(a => a.Date == freeTimeSlots.LastOrDefault().TimeSlot).FirstOrDefault() != null)
                        {
                            freeTimeSlots.LastOrDefault().IsRegistered = true;
                        }
                        currentDay = currentDay.AddMinutes(daySchedule.SlotDuration);
                    }
                }
                currentDay = DateTime.Now.Date;
                currentDay = currentDay.AddDays(i + 1);
            }

            return freeTimeSlots;
        }

        public async Task<int> Create(ScheduleDTO scheduleDTO)
        {
            int result = await _unitOfWork.Schedules.Create(_mapper.Map<Schedule>(scheduleDTO));
            return result;
        }

        public async Task<int> Update(ScheduleDTO scheduleDTO)
        {
            int result = await _unitOfWork.Schedules.Update(_mapper.Map<Schedule>(scheduleDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Schedules.Delete(id);
            return result;
        }
    }
}
