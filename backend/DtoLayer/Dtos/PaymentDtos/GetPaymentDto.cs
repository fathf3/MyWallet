namespace DtoLayer.Dtos.PaymentDtos
{
	public class GetPaymentDto
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime PaymentDate { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
        public bool Status { get; set; }
    }
}
