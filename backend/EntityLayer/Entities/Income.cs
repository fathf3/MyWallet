using CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Income : EntityBase, IEntityBase
	{
		public Income() { }
		public Income(decimal cost, string description, DateTime incomeDate, int categoryId, bool status)
		{
			Cost = cost;
			Description = description;
			IncomeDate = incomeDate;
			CategoryId = categoryId;
			Status = status;
		}

		public decimal Cost { get; set; }
        public string Description { get; set; }
        public DateTime IncomeDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        

    }
}
