using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PatientService : IPatientService
    {
        IUnitOfWork _unitOfWork { get; set; }
        IMapper _mapper;

        public PatientService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(PatientDTO patientDTO)
        {
            int result = await _unitOfWork.Patients.Create(_mapper.Map<Patient>(patientDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Patients.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<PatientDTO>> GetAll()
        {
            IEnumerable<Patient> patients = await _unitOfWork.Patients.GetAll();
            return _mapper.Map<List<PatientDTO>>(patients);
        }
        
        public async Task<PatientDTO> GetById(int id)
        {
            Patient patient = await _unitOfWork.Patients.GetById(id);
            PatientDTO result = _mapper.Map<PatientDTO>(patient);
            return result;
        }

        public async Task<int> Update(PatientDTO patientDTO)
        {
            int result = await _unitOfWork.Patients.Update(_mapper.Map<Patient>(patientDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<PatientUserDTO>> SearchPatient(string fullName)
        {
            var patientUser = new List<PatientUserDTO>();
            IList<User> users = await _unitOfWork.Users.SearchUsers(fullName);


            foreach (var user in users)
            {
                Patient patient = await _unitOfWork.Patients.GetByUserId(user.Id);
                if (patient != null)
                {
                    patientUser.Add(new PatientUserDTO() { FullName = user.FullName, PatientId = patient.Id});
                }
            }

            return patientUser;
        }
    }
}
