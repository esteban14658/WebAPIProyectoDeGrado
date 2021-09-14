﻿using AutoMapper;
using PG.Bussiness.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ResidentService: GenericService<ResidentDTO, CreateResidentDTO, Resident>, IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public ResidentService(IResidentRepository residentRepository, IMapper mapper): base(residentRepository, mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<ResidentDTO> GetUserByEmail(string email)
        {
            var exist = _residentRepository.ExistUserByEmail(email);
            if (!exist)
            {
                throw new KeyNotFoundException("Resident not found");
            }
            var genericResult = await _residentRepository.GetUserByEmail(email);
            var residentDTO = _mapper.Map<ResidentDTO>(genericResult);
            return residentDTO;
        }

        public async Task<ResidentDTO> GetUserById(int id)
        {
            var exist = _residentRepository.ExistUserById(id);
            if (!exist)
            {
                throw new KeyNotFoundException("recycler not found");
            }
            var genericResult = await _residentRepository.GetUserById(id);
            var residentDTO = _mapper.Map<ResidentDTO>(genericResult);
            return residentDTO;
        }

        public override async Task<CreateResidentDTO> Insert(CreateResidentDTO dto)
        {
            var user = _residentRepository.ExistUserByEmail(dto.User.Email);
            if (user)
            {
                throw new CustomConflictException("User already exist");
            }
            var resident = _mapper.Map<Resident>(dto);
            await _residentRepository.Insert(resident);
            return dto;
        }

        public override async Task<CreateResidentDTO> Update(CreateResidentDTO dto, int id)
        {
            var exist = _residentRepository.Exists(id);
            
            if (!exist)
            {
                throw new KeyNotFoundException("Resident not found");
            }
            
            var resident = _mapper.Map<Resident>(dto);
            resident.Id = id;
            

            await _residentRepository.Update(resident);
            return dto;
        }
    }
}
