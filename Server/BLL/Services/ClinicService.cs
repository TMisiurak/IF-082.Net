using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(ClinicDTO clinicDTO)
        {
            int result = await _unitOfWork.Clinics.Create(_mapper.Map<Clinic>(clinicDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Clinics.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async  Task<IList<ClinicDTO>> GetAll()
        {
            IList<Clinic> clinics = await _unitOfWork.Clinics.GetAll();
            var result = _mapper.Map<IList<ClinicDTO>>(clinics);
            return result;
        }

        public async Task<ClinicDTO> GetById(int id)
        {
            Clinic clinic = await _unitOfWork.Clinics.GetById(id);
            ClinicDTO result = _mapper.Map<ClinicDTO>(clinic);
            return result;
        }

        public async Task<int> Update(ClinicDTO clinicDTO)
        {
            int result = await _unitOfWork.Clinics.Update(_mapper.Map<Clinic>(clinicDTO));
            _unitOfWork.Commit();
            return result;
        }
    }
}
