using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(AppointmentDTO appointment)
        {
            int result = await DataBase.Appointments.Create(_mapper.Map<Appointment>(appointment));
            DataBase.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Appointments.Delete(id);
            DataBase.Commit();
            return result;
        }

        public async Task<IList<AppointmentDTO>> GetAll()
        {
            IList<Appointment> appointment = await DataBase.Appointments.GetAll();
            var result = _mapper.Map<IList<AppointmentDTO>>(appointment);
            return result;
        }

        public async Task<AppointmentDTO> GetById(int id)
        {
            Appointment appointment = await DataBase.Appointments.GetById(id);
            AppointmentDTO result = _mapper.Map<AppointmentDTO>(appointment);
            return result;
        }

        public async Task<int> Update(AppointmentDTO appointment)
        {
            int result = await DataBase.Appointments.Update(_mapper.Map<Appointment>(appointment));
            DataBase.Commit();
            return result;
        }
    }
}
