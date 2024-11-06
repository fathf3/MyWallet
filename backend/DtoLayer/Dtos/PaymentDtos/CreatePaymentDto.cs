using DtoLayer.Dtos.CategoryDtos;
using DtoLayer.Dtos.CustomerDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.PaymentDtos
{
	public class CreatePaymentDto
	{
		public int CustomerId { get; set; }
		public DateTime PaymentDate { get; set; }
        public DateTime PaymentPeriod { get; set; }
        public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public IList<ResultCategoryDto> Categories { get; set; }
        public IList<ResultCustomerForPaymentDto> Customers { get; set; }
    }
}
