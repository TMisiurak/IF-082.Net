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
    public class PrescriptionListService : IPrescriptionListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionListService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(PrescriptionListDTO prescriptionListDTO)
        {
            int result = await _unitOfWork.PrescriptionLists.Create(_mapper.Map<PrescriptionList>(prescriptionListDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.PrescriptionLists.Delete(id);
            return result;
        }

        public async Task<IList<PrescriptionListDTO>> GetAll()
        {
            IList<PrescriptionList> prescriptionLists = await _unitOfWork.PrescriptionLists.GetAll();
            var result = _mapper.Map<IList<PrescriptionListDTO>>(prescriptionLists);
            return result;
        }

        public async Task<PrescriptionListDTO> GetById(int id)
        {
            PrescriptionList prescriptionList = await _unitOfWork.PrescriptionLists.GetById(id);
            PrescriptionListDTO result = _mapper.Map<PrescriptionListDTO>(prescriptionList);
            return result;
        }

        public async Task<int> Update(PrescriptionListDTO prescriptionListDTO)
        {
            int result = await _unitOfWork.PrescriptionLists.Update(_mapper.Map<PrescriptionList>(prescriptionListDTO));
            return result;
        }
    }
}