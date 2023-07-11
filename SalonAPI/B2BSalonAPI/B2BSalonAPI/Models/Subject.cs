using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }
        public string? SubjectName { get; set; }
    }
}
