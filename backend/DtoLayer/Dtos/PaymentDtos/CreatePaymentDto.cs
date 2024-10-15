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
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
        public bool Status { get; set; }
    }
}
