namespace DtoLayer.Dtos.IncomeDtos
{
	public class UpdateIncomeDto
	{
		public int Id { get; set; }
		public decimal Cost { get; set; }
		public string Description { get; set; }
		public DateTime IncomeDate { get; set; }
		public int CategoryId { get; set; }
        public bool Status { get; set; }
    }
}
