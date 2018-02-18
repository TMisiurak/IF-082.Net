using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProcedureService : IProcedureService
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
            DataBase.Commit(result);
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Procedures.Delete(id);
            DataBase.Commit(result);
            return result;
        }

        public async Task<IList<ProcedureDTO>> GetAll()
        {
            IList<Procedure> procedures = await DataBase.Procedures.GetAll();
            var result = _mapper.Map<IList<ProcedureDTO>>(procedures);
            return result;
        }

        public async Task<ProcedureDTO> GetById(int id)
        {
            Procedure procedure = await DataBase.Procedures.GetById(id);
            ProcedureDTO result = _mapper.Map<ProcedureDTO>(procedure);
            return result;
        }

        public async Task<int> Update(ProcedureDTO procedureDTO)
        {
            int result = await DataBase.Procedures.Update(_mapper.Map<Procedure>(procedureDTO));
            DataBase.Commit(result);
            return result;
        }
    }
}
