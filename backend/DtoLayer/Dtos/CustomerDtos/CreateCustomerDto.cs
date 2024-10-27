using DtoLayer.Dtos.ActivityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.CustomerDtos
{
	public class CreateCustomerDto
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public bool Status { get; set; }
        public int ActivityId { get; set; }
        public IList<ResultActivityDto> Activities { get; set; }

    }
}
