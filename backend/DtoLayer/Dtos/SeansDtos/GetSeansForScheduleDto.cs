using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SeansDtos
{
    public class GetSeansForScheduleDto
    {
      
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Activity Activity { get; set; }
        
    }
}
