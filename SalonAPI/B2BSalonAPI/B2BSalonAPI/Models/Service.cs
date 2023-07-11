using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class Service
    {
        [Key]
        public Guid ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int DurationHours { get; set; }
        public int DurationMinutes { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BranchId { get; set; }
        public Branch? Branch { get; set; }        
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
