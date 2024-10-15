using CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Category : EntityBase, IEntityBase
	{
		public Category() { }
		public Category(string name, bool categoryType, bool status)
		{
			Name = name;
			CategoryType = categoryType;
			Status = status;
		}

		public string Name { get; set; }
        public bool CategoryType { get; set; }
        public bool Status { get; set; }  

        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
