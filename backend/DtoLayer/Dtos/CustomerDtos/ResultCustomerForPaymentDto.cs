using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DtoLayer.Dtos.CustomerDtos
{
    public class ResultCustomerForPaymentDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
       
        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }
    }
    
}
