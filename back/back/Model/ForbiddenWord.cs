using System.ComponentModel.DataAnnotations;

namespace back.Model
{
    public class ForbiddenWord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Word { get; set; }
        public ForbiddenWord()
        {
        }
    }
}
