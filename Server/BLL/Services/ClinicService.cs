using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class ClinicService : IService<ClinicDTO>
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public ClinicService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(ClinicDTO clinicDTO)
        {
            int result = await DataBase.Clinics.Create(_mapper.Map<Clinic>(clinicDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Clinics.Delete(id);
            return result;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public async  Task<List<ClinicDTO>> GetAll()
        {
            List<Clinic> clinics = await DataBase.Clinics.GetAll();
            var result = _mapper.Map<List<ClinicDTO>>(clinics);
            return result;
        }

        public async Task<ClinicDTO> GetById(int id)
        {
            Clinic clinic = await DataBase.Clinics.GetById(id);
            ClinicDTO result = _mapper.Map<ClinicDTO>(clinic);
            return result;
        }

        public Task<int> Update(ClinicDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
