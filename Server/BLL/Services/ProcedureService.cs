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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProcedureService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(ProcedureDTO procedureDTO)
        {
            int result = await _unitOfWork.Procedures.Create(_mapper.Map<Procedure>(procedureDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Procedures.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<ProcedureDTO>> GetAll()
        {
            IList<Procedure> procedures = await _unitOfWork.Procedures.GetAll();
            var result = _mapper.Map<IList<ProcedureDTO>>(procedures);
            return result;
        }

        public async Task<ProcedureDTO> GetById(int id)
        {
            Procedure procedure = await _unitOfWork.Procedures.GetById(id);
            ProcedureDTO result = _mapper.Map<ProcedureDTO>(procedure);
            return result;
        }

        public async Task<int> Update(ProcedureDTO procedureDTO)
        {
            int result = await _unitOfWork.Procedures.Update(_mapper.Map<Procedure>(procedureDTO));
            _unitOfWork.Commit();
            return result;
        }
    }
}
