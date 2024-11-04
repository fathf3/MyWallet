using AutoMapper;
using DtoLayer.Dtos.SeansDtos;
using EntityLayer.Entities;

namespace BusinessLayer.AutoMapper
{
    public class SeansProfile : Profile
    {
        public SeansProfile()
        {
            CreateMap<Seans, CreateSeansDto>().ReverseMap();
            CreateMap<Seans, ResultSeansDto>().ReverseMap();
            CreateMap<Seans, UpdateSeansDto>().ReverseMap();
            CreateMap<Seans, GetSeansDto>().ReverseMap();
            CreateMap<UpdateSeansDto, GetSeansDto>().ReverseMap();
        }
    }
}
