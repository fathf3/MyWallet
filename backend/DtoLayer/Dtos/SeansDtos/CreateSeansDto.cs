using DtoLayer.Dtos.ActivityDtos;
using DtoLayer.Dtos.CategoryDtos;
using DtoLayer.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SeansDtos
{
    public class CreateSeansDto
    {
        public int ActivityId { get; set; }
        public int CustomerId { get; set; }
        public int SeansCount { get; set; }
        public bool Status { get; set; }
        public IList<ResultActivityDto> Activities { get; set; }
        public IList<ResultCustomerForPaymentDto> Customers { get; set; }
        public DateTime Date { get; set; }
    }
}
