using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DtoLayer.Dtos.ActivityDtos;
using DtoLayer.Dtos.SeansDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concretes
{
    public class SeansManager : ISeansService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeansManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> ActiveSeansAsync(int id)
        {
            var seans = await _unitOfWork.GetRepository<Seans>().GetByIdAsync(id);
            seans.Status = true;
            await _unitOfWork.GetRepository<Seans>().UpdateAsync(seans);
            await _unitOfWork.SaveAsync();
            return seans.Id.ToString();
        }

        public async Task CreateSeansAsync(CreateSeansDto createDto)
        {
            var tarih = createDto.Date;
            for (int i = 0;i< createDto.SeansCount; i++)
            {
                
                createDto.Date = tarih.AddDays(i*7);
                createDto.Status = true;
                var map = _mapper.Map<Seans>(createDto);
                await _unitOfWork.GetRepository<Seans>().AddAsync(map);
                await _unitOfWork.SaveAsync();

            }
            
        }

        public async Task<string> DeleteSeansAsync(int id)
        {
            var seans = await _unitOfWork.GetRepository<Seans>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Seans>().DeleteAsync(seans);
            return seans.Id.ToString();

        }

        public async Task<List<GetSeansForScheduleDto>> GetAllSeans()
        {
            var seans = await _unitOfWork
               .GetRepository<Seans>()
               .GetAllAsync(null, x => x.Customer, y => y.Activity);
            var map = _mapper.Map<List<GetSeansForScheduleDto>>(seans);
            return map;
        }

        public async Task<List<ResultSeansDto>> GetAllSeansWithCustomer(int id)
        {
            var seans = await _unitOfWork
                .GetRepository<Seans>()
                .GetAllAsync(x => x.CustomerId == id);
            
            var map = _mapper.Map<List<ResultSeansDto>>(seans);
            return map;
        }

        public async Task<GetSeansDto> GetSeansById(int id)
        {
            var result =await _unitOfWork.GetRepository<Seans>().GetByIdAsync(id);
            var map = _mapper.Map<GetSeansDto>(result);
            return map;
        }

        public async Task<string> PassiveSeansAsync(int id)
        {
            var seans = await _unitOfWork.GetRepository<Seans>().GetByIdAsync(id);
            seans.Status = false;
            await _unitOfWork.GetRepository<Seans>().UpdateAsync(seans);
            await _unitOfWork.SaveAsync();
            return seans.Id.ToString();
        }

        public async Task<bool> UpdateAsync(UpdateSeansDto updateSeansDto)
        {
            updateSeansDto.Status = true;
            var map = _mapper.Map<Seans>(updateSeansDto);
            await _unitOfWork.GetRepository<Seans>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
