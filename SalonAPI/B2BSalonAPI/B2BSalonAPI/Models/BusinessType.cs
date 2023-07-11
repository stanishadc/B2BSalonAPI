using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class BusinessType
    {
        [Key]
        public Guid BusinessTypeId { get; set; }
        public string? BusinessTypeName { get; set; }        
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? BusinessTypeURL { get; set; }
    }
}
