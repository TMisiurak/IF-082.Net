using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DrugService : IDrugService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DrugService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<DrugDTO> GetById(int id)
        {
            Drug drug = await _unitOfWork.Drugs.GetById(id);
            DrugDTO result = _mapper.Map<DrugDTO>(drug);
            return result;
        }

        public async Task<IList<DrugDTO>> GetAll()
        {
            IList<Drug> drugs = await _unitOfWork.Drugs.GetAll();
            var result = _mapper.Map<IList<DrugDTO>>(drugs);
            return result;
        }

        public async Task<int> Create(DrugDTO drugDTO)
        {
            int result = await _unitOfWork.Drugs.Create(_mapper.Map<Drug>(drugDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> Update(DrugDTO drugDTO)
        {
            int result = await _unitOfWork.Drugs.Update(_mapper.Map<Drug>(drugDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Drugs.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        //public void Dispose()
        //{
        //    DataBase.Dispose();
        //}
    }
}
