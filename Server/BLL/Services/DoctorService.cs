using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<IList<DoctorDTO>> GetAll()
        {
            IList<Doctor> doctors = await _unitOfWork.Doctors.GetAll();
            var result = _mapper.Map<IList<DoctorDTO>>(doctors);
            return result;
        }

        public async Task<DoctorDTO> GetById(int id)
        {
            Doctor doctor = await _unitOfWork.Doctors.GetById(id);
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<int> Create(DoctorDTO doctorDTO)
        {
            int result = await _unitOfWork.Doctors.Create(_mapper.Map<Doctor>(doctorDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> Update(DoctorDTO doctorDTO)
        {
            int result = await _unitOfWork.Doctors.Update(_mapper.Map<Doctor>(doctorDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Doctors.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<DoctorUserDTO>> SearchDotor(string fullName)
        {
            var doctorUser = new List<DoctorUserDTO>();
            IList<User> users = await _unitOfWork.Users.SearchUsers(fullName);


            foreach (var user in users)
            {
                Doctor doctor = await _unitOfWork.Doctors.GetByUserId(user.Id);
                if (doctor != null)
                {
                    doctorUser.Add(new DoctorUserDTO() { FullName = user.FullName, DoctorId = doctor.Id, Speciality = doctor.Speciality });
                }
            }

            return doctorUser;
        }
    }
}
