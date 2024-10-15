using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.IncomeDtos
{
    public class DashboardIncomeDto
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime IncomeDate { get; set; }
    }
}
