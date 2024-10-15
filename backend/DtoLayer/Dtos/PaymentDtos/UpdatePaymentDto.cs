using DtoLayer.Dtos.CustomerDtos;

namespace DtoLayer.Dtos.PaymentDtos
{
	public class UpdatePaymentDto
	{
        public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime PaymentDate { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
        public bool Status { get; set; }
        public IList<ResultCustomerDto> Customers { get; set; }
    }
}
