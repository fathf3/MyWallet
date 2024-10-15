using AutoMapper;
using DtoLayer.Dtos.IncomeDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
	public class IncomesProfile : Profile
	{
		public IncomesProfile()
		{
			CreateMap<Income, CreateIncomeDto>().ReverseMap();
			CreateMap<Income, UpdateIncomeDto>().ReverseMap();
			CreateMap<Income, ResultIncomeDto>().ReverseMap();
			CreateMap<Income, GetIncomeDto>().ReverseMap();
			CreateMap<UpdateIncomeDto, GetIncomeDto>().ReverseMap();
			CreateMap<Income, DashboardIncomeDto>().ReverseMap();
		}
	}
}
