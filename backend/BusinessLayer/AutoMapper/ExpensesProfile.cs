using AutoMapper;
using DtoLayer.Dtos.ExpenseDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
	public class ExpensesProfile : Profile
	{
		public ExpensesProfile()
		{
			CreateMap<Expense, CreateExpenseDto>().ReverseMap();
			CreateMap<Expense, UpdateExpenseDto>().ReverseMap();
			CreateMap<Expense, ResultExpenseDto>().ReverseMap();
			CreateMap<Expense, GetExpenseDto>().ReverseMap();
			CreateMap<UpdateExpenseDto, GetExpenseDto>().ReverseMap();
			CreateMap<ResultExpenseDto, GetMonthlyExpenseDto>().ReverseMap();
			CreateMap<Expense, GetMonthlyExpenseDto>().ReverseMap();
		}
	}
}
