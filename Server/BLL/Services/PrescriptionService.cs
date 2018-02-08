﻿using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public PrescriptionService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(PrescriptionDTO prescriptionDTO)
        {
            int result = await DataBase.Prescriptions.Create(_mapper.Map<Prescription>(prescriptionDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Prescriptions.Delete(id);
            return result;
        }

        public async Task<IList<PrescriptionDTO>> GetAll()
        {
            IList<Prescription> prescriptions = await DataBase.Prescriptions.GetAll();
            var result = _mapper.Map<IList<PrescriptionDTO>>(prescriptions);
            return result;
        }

        public async Task<PrescriptionDTO> GetById(int id)
        {
            Prescription prescription = await DataBase.Prescriptions.GetById(id);
            PrescriptionDTO result = _mapper.Map<PrescriptionDTO>(prescription);
            return result;
        }

        public Task<int> Update(PrescriptionDTO item)
        {
            throw new NotImplementedException();
        }
    }
}