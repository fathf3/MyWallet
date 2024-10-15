using DtoLayer.Dtos.CategoryDtos;

namespace DtoLayer.Dtos.IncomeDtos
{
	public class ResultIncomeDto
	{
		public int Id { get; set; }
		public decimal Cost { get; set; }
		public string Description { get; set; }
		public DateTime IncomeDate { get; set; }
		public GetCategoryDto Category { get; set; }
        public bool Status { get; set; }
    }
}
