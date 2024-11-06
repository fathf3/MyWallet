using CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Customer : EntityBase, IEntityBase
	{
		public Customer() { }
		public Customer(string name, string lastName, string phone, bool status, int activityId)
		{
			Name = name;
			LastName = lastName;
			Phone = phone;
			Status = status;
			ActivityId = activityId;
		}

		public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
		[ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Seans> Seans { get; set; }
        
    }
	
}
