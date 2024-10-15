using AutoMapper;
using DtoLayer.Dtos.PaymentDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
	public class PaymentsProfile : Profile
	{
		public PaymentsProfile()
		{
			CreateMap<Payment, CreatePaymentDto>().ReverseMap();
			CreateMap<Payment, UpdatePaymentDto>().ReverseMap();
			CreateMap<Payment, ResultPaymentDto>().ReverseMap();
			CreateMap<Payment, GetPaymentDto>().ReverseMap();
			CreateMap<UpdatePaymentDto, GetPaymentDto>().ReverseMap();
		}
	}
}
