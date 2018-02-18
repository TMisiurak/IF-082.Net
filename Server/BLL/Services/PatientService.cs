using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using ProjectCore;
using DAL.Interfaces;
using ProjectCore.Entities;
using ProjectCore.DTO;

namespace BLL.Services

{
    public class PatientService : IPatientService
    {
        IUnitOfWork Database { get; set; }
        IMapper _mapper;

        public PatientService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(PatientDTO patientDTO)
        {
            int result = await Database.Patients.Create(_mapper.Map<Patient>(patientDTO));
            Database.Commit(result);
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await Database.Patients.Delete(id);
            Database.Commit();
            return result;
        }

        public async Task<IList<PatientDTO>> GetAll()
        {
            IEnumerable<Patient> patients = await Database.Patients.GetAll();
            return _mapper.Map<List<PatientDTO>>(patients);
        }
        ///
        public async Task<PatientDTO> GetById(int id)
        {
            Patient patient = await Database.Patients.GetById(id);
            PatientDTO result = _mapper.Map<PatientDTO>(patient);
            return result;
        }

        public async Task<int> Update(PatientDTO patientDTO)
        {
            int result = await Database.Patients.Update(_mapper.Map<Patient>(patientDTO));
            Database.Commit();
            return result;
        }
    }
}
