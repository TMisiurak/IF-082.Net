using System.Collections.Generic;
using BLL.Interfaces;
using AutoMapper;
using DAL.Interfaces;
using System.Threading.Tasks;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace BLL.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiagnosisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(DiagnosisDTO diagnosisDTO)
        {
            int result = await _unitOfWork.Diagnoses.Create(_mapper.Map<Diagnosis>(diagnosisDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Diagnoses.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<DiagnosisDTO>> GetAll()
        {
            IList<Diagnosis> diagnoses = await _unitOfWork.Diagnoses.GetAll();
            var result = _mapper.Map<IList<DiagnosisDTO>>(diagnoses);
            return result;
        }

        public async Task<DiagnosisDTO> GetById(int id)
        {
            Diagnosis diagnosis = await _unitOfWork.Diagnoses.GetById(id);
            var result = _mapper.Map<DiagnosisDTO>(diagnosis);
            return result;
        }

        public async Task<int> Update(DiagnosisDTO diagnosisDTO)
        {
            int result = await _unitOfWork.Diagnoses.Update(_mapper.Map<Diagnosis>(diagnosisDTO));
            _unitOfWork.Commit();
            return result;
        }
    }
}
