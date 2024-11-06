﻿using DtoLayer.Dtos.CategoryDtos;
using DtoLayer.Dtos.CustomerDtos;

namespace DtoLayer.Dtos.PaymentDtos
{
	public class ResultPaymentDto
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
        public GetCustomerDto Customer { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentPeriod { get; set; }
		public GetCategoryDto Category { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
        public bool Status { get; set; }
    }
}
