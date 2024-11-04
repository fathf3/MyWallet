using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ExpenseDtos
{
    public class GetMonthlyExpenseDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
