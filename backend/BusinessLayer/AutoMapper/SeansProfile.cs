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
        }
    }
}
