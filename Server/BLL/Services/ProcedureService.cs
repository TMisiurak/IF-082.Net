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
    public class ProcedureService : IService<ProcedureDTO>
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public ProcedureService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(ProcedureDTO procedureDTO)
        {
            int result = await DataBase.Procedures.Create(_mapper.Map<Procedure>(procedureDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Procedures.Delete(id);
            return result;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public async Task<List<ProcedureDTO>> GetAll()
        {
            List<Procedure> procedures = await DataBase.Procedures.GetAll();
            var result = _mapper.Map<List<ProcedureDTO>>(procedures);
            return result;
        }

        public async Task<ProcedureDTO> GetById(int id)
        {
            Procedure procedure = await DataBase.Procedures.GetById(id);
            ProcedureDTO result = _mapper.Map<ProcedureDTO>(procedure);
            return result;
        }

        public Task<int> Update(ProcedureDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
