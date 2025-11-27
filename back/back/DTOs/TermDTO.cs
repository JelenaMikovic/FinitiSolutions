namespace back.DTOs
{
    public class TermDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
