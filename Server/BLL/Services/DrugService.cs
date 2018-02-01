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
    public class DrugService : IService<DrugDTO>
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public DrugService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<DrugDTO> GetById(int id)
        {
            Drug drug = await DataBase.Drugs.GetById(id);
            DrugDTO result = _mapper.Map<DrugDTO>(drug);
            return result;
        }
        


        public async Task<List<DrugDTO>> GetAll()
        {
            List<Drug> drugs = await DataBase.Drugs.GetAll();
            var result = _mapper.Map<List<DrugDTO>>(drugs);
            return result;
        }

        public async Task<int> Create(DrugDTO drugDTO)
        {
            int result = await DataBase.Drugs.Create(_mapper.Map<Drug>(drugDTO));
            return result;
        }

        public async Task<int> Update(DrugDTO drugDTO)
        {
            int result = await DataBase.Drugs.Update(_mapper.Map<Drug>(drugDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {

            int result = await DataBase.Drugs.Delete(id);
            return result;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
