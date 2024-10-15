using DtoLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ExpenseDtos
{
	public class CreateExpenseDto
	{
		public decimal Cost { get; set; }
		public string Description { get; set; }
		public DateTime ExpenseDate { get; set; }
		public int CategoryId { get; set; }
        public IList<ResultCategoryDto> Categories { get; set; }
        public bool Status { get; set; }
    }
}
