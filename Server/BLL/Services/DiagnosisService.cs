using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL.Interfaces;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DiagnosisService : IService<DiagnosisDTO>
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public DiagnosisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            DataBase = unitOfWork;
        }

        public async Task<int> Create(DiagnosisDTO diagnosisDTO)
        {
            int result = await DataBase.Diagnosis.Create(_mapper.Map<Diagnosis>(diagnosisDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Diagnosis.Delete(id);
            return result;
        }

        public async Task<List<DiagnosisDTO>> GetAll()
        {
            List<Diagnosis> diagnosis = await DataBase.Diagnosis.GetAll();
            var result = _mapper.Map<List<DiagnosisDTO>>(diagnosis);
            return result;
        }

        public async Task<DiagnosisDTO> GetById(int id)
        {
            Diagnosis diagnosis = await DataBase.Diagnosis.GetById(id);
            var result = _mapper.Map<DiagnosisDTO>(diagnosis);
            return result;
        }

        public async Task<int> Update(DiagnosisDTO diagnosisDTO)
        {
            int result = await DataBase.Diagnosis.Update(_mapper.Map<Diagnosis>(diagnosisDTO));
            return result;
        }
    }
}
