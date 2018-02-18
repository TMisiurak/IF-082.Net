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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(PrescriptionDTO prescriptionDTO)
        {
            int result = await _unitOfWork.Prescriptions.Create(_mapper.Map<Prescription>(prescriptionDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Prescriptions.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<PrescriptionDTO>> GetAll()
        {
            IList<Prescription> prescriptions = await _unitOfWork.Prescriptions.GetAll();
            var result = _mapper.Map<IList<PrescriptionDTO>>(prescriptions);
            return result;
        }

        public async Task<PrescriptionDTO> GetById(int id)
        {
            Prescription prescription = await _unitOfWork.Prescriptions.GetById(id);
            PrescriptionDTO result = _mapper.Map<PrescriptionDTO>(prescription);
            return result;
        }

        public async Task<int> Update(PrescriptionDTO prescriptionDTO)
        {
            int result = await _unitOfWork.Prescriptions.Update(_mapper.Map<Prescription>(prescriptionDTO));
            _unitOfWork.Commit();
            return result;
        }
    }
}
