using DtoLayer.Dtos.CategoryDtos;

namespace DtoLayer.Dtos.IncomeDtos
{
	public class GetIncomeDto
	{
		public int Id { get; set; }
		public decimal Cost { get; set; }
		public string Description { get; set; }
		public DateTime IncomeDate { get; set; }
		public int CategoryId { get; set; }
        public IList<ResultCategoryDto> Categories { get; set; }
        public bool Status { get; set; }
    }
}
