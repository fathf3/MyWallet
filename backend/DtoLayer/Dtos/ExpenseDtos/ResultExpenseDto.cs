namespace DtoLayer.Dtos.ExpenseDtos
{
	public class ResultExpenseDto
	{
		public int Id { get; set; }
		public decimal Cost { get; set; }
		public string Description { get; set; }
		public DateTime ExpenseDate { get; set; }
		public int CategoryId { get; set; }
        public bool Status { get; set; }
    }
}
