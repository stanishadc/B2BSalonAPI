using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2BSalonAPI.DTO
{
    public class BusinessDTO
    {
        public Guid BusinessId { get; set; }
        [Required(ErrorMessage = "Business Name is required")]
        public string? BusinessName { get; set; }
        public string? Id { get; set; }
        public string? BranchType { get; set; }//Main branch or sub branch
        public string? BranchUrl { get; set; }
        public string? ContactName { get; set; }
        public string? Landline { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public Guid BusinessTypeId { get; set; }
        public string? Address { get; set; }
        public string? GoogleMapURL { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? About { get; set; }
        public string? Currency { get; set; }
        public int TotalRatings { get; set; }
        public double Rating { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Password { get; set; }
        public string? ImageName { get; set; }
        public Guid SubscriptionId { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
