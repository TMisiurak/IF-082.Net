using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using ProjectCore.Helpers;
using System.Collections.Generic;
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
