namespace DtoLayer.Dtos.CustomerDtos
{
	public class GetCustomerDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
        public int ActivityId { get; set; }
        public bool Status { get; set; }
	}
}
