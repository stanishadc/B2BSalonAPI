using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Categoryurl { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
