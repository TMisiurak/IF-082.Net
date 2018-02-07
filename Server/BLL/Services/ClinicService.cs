using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClinicService : IService<ClinicDTO>
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

        public async Task<int> Update(ClinicDTO clinicDTO)
        {
            int result = await DataBase.Clinics.Update(_mapper.Map<Clinic>(clinicDTO));
            return result;
        }
    }
}
