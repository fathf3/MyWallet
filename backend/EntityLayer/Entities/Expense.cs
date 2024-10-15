using CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Expense : EntityBase, IEntityBase
	{
		public Expense() { }
		public Expense(decimal cost, string description, DateTime expenseDate, int categoryId, bool status)
		{
			Cost = cost;
			Description = description;
			ExpenseDate = expenseDate;
			CategoryId = categoryId;
			Status = status;
		}

		public decimal Cost { get; set; }
		public string Description { get; set; }
		public DateTime ExpenseDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
