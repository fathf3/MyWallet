using CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Seans : EntityBase, IEntityBase
    {
        public Seans() { }

        public Seans(int customerId, int activityId, DateTime date, int seansCount)
        {
            CustomerId = customerId;
            ActivityId = activityId;
            Date = date;
            SeansCount = seansCount;
        }
        public int SeansCount { get; set; }
        public bool Status { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
       
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public DateTime Date { get; set; }
    }
}
