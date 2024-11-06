using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DtoLayer.Dtos.ActivityDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concretes
{
    public class ActivityManager : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateActivityAsync(CreateActivityDto createDto)
        {
            var map = _mapper.Map<Activity>(createDto);
            await _unitOfWork.GetRepository<Activity>().AddAsync(map);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> DeleteActivityAsync(int id)
        {
            var activity = await _unitOfWork.GetRepository<Activity>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Activity>().DeleteAsync(activity);
            await _unitOfWork.SaveAsync();
            return activity.Name;
        }

        public async Task<GetActivityDto> GetActivityById(int id)
        {
            var activity = await _unitOfWork.GetRepository<Activity>().GetByIdAsync(id);
            
            var map = _mapper.Map<GetActivityDto>(activity);
            return map;
        }

        public async Task<List<ResultActivityDto>> GetAllActivities()
        {
            var activity = await _unitOfWork.GetRepository<Activity>().GetAllAsync();
            var map = _mapper.Map<List<ResultActivityDto>>(activity);
            return map;
        }

        public async Task<string> UpdateActivityAsync(UpdateActivityDto updateDto)
        {
            var map = _mapper.Map<Activity>(updateDto);
            await _unitOfWork.GetRepository<Activity>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
            return updateDto.Name;
        }
    }
}
