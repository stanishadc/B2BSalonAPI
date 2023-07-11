using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class FAQ
    {
        [Key]
        public Guid FAQId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public Guid SubjectId { get;set; }
        public Subject? Subject { get; set; }
    }
}
