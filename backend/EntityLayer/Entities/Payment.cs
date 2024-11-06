using CoreLayer.Entites;

namespace EntityLayer.Entities
{
	public class Payment : EntityBase, IEntityBase
	{
		public Payment() { }
		public Payment(int customerId, decimal amount, bool isPaid )
		{
			CustomerId = customerId;
			
			Amount = amount;
			IsPaid = isPaid;
			
    }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
		public DateTime PaymentDate { get; set; }
        public DateTime PaymentPeriod { get; set; }
        public bool Status { get; set; }
        public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
	
}
