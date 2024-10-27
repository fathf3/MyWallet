using DtoLayer.Dtos.ActivityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
    public interface IActivityService
    {
        Task<List<ResultActivityDto>> GetAllActivities();
        Task CreateActivityAsync(CreateActivityDto createDto);
        Task<GetActivityDto> GetActivityById(int id);
        Task<string> UpdateActivityAsync(UpdateActivityDto updateDto);
        Task<string> DeleteActivityAsync(int id);
    }
}
