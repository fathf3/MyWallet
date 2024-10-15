using CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Customer : EntityBase, IEntityBase
	{
		public Customer() { }
		public Customer(string name, string lastName, string phone, bool status)
		{
			Name = name;
			LastName = lastName;
			Phone = phone;
			Status = status;
		}

		public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public ICollection<Payment> Payments { get; set; }
	}
	
}
