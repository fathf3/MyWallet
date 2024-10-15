using CoreLayer.Entites;

namespace EntityLayer.Entities
{
	public class Payment : EntityBase, IEntityBase
	{
		public Payment() { }
		public Payment(int customerId, DateTime paymentDate, decimal amount, bool isPaid)
		{
			CustomerId = customerId;
			PaymentDate = paymentDate;
			Amount = amount;
			IsPaid = isPaid;
		}

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public DateTime PaymentDate { get; set; }

		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
	
}
