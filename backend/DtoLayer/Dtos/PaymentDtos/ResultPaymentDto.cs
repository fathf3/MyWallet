namespace DtoLayer.Dtos.PaymentDtos
{
	public class ResultPaymentDto
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime PaymentDate { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
}
