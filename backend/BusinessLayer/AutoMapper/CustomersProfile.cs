using AutoMapper;
using DtoLayer.Dtos.CustomerDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
	public class CustomersProfile : Profile
	{
		public CustomersProfile()
		{
			CreateMap<Customer, CreateCustomerDto>().ReverseMap();
			CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
			CreateMap<Customer, ResultCustomerDto>().ReverseMap();
			CreateMap<Customer, GetCustomerDto>().ReverseMap();
			CreateMap<UpdateCustomerDto, GetCustomerDto>().ReverseMap();
		}
	}
}
