using back;
using System.ComponentModel.DataAnnotations;

namespace back.Model
{
    public enum TermStatus
    {
        PUBLISHED, DRAFT, ARCHIVED
    }
    public class Term
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public TermStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public Term() { }   
    }
}
