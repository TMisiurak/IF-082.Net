using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public DoctorService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<IList<DoctorDTO>> GetAll()
        {
            IList<Doctor> doctors = await DataBase.Doctors.GetAll();
            var result = _mapper.Map<IList<DoctorDTO>>(doctors);
            return result;
        }

        public async Task<DoctorDTO> GetById(int id)
        {
            Doctor doctor = await DataBase.Doctors.GetById(id);
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<int> Create(DoctorDTO doctorDTO)
        {
            int result = await DataBase.Doctors.Create(_mapper.Map<Doctor>(doctorDTO));
            DataBase.Commit();
            return result;
        }

        public async Task<int> Update(DoctorDTO doctorDTO)
        {
            int result = await DataBase.Doctors.Update(_mapper.Map<Doctor>(doctorDTO));
            DataBase.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Doctors.Delete(id);
            DataBase.Commit();
            return result;
        }
    }
}
