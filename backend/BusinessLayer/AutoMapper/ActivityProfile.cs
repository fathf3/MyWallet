using AutoMapper;
using DtoLayer.Dtos.ActivityDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, CreateActivityDto>().ReverseMap();
            CreateMap<Activity, UpdateActivityDto>().ReverseMap();
            CreateMap<Activity, ResultActivityDto>().ReverseMap();
            CreateMap<Activity, GetActivityDto>().ReverseMap();
            CreateMap<UpdateActivityDto, GetActivityDto>().ReverseMap();
        }
    }
}
