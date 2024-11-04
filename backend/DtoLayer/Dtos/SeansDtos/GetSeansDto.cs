namespace DtoLayer.Dtos.SeansDtos
{
    public class GetSeansDto
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int CustomerId { get; set; }
        public int SeansCount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
