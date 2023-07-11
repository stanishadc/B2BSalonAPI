using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2BSalonAPI.Models
{
    public class Business
    {
        [Key]
        public Guid BusinessId { get; set; }
        public string? BusinessName { get; set; }
    }
    public class BranchSubscription
    {
        [Key]
        public Guid BranchSubscriptionId { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }
        public Guid SubscriptionTypeId { get; set; }        
        public Branch? Branch { get; set; }
        public Guid BranchId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PGReference { get; set; }
    }
    public class Branch
    {
        [Key]
        public Guid BranchId { get; set; }
        public Guid BusinessId { get; set; }
        public User? User { get; set; }
        public string? Id { get; set; }
        public string? BranchType { get; set; }//Main branch or sub branch
        public string? BranchUrl { get; set; }
        public string? ContactName { get; set; }
        public string? Landline { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public BusinessType? BusinessType { get; set; }
        public Guid BusinessTypeId { get; set; }
        public string? Address { get; set; }
        public string? GoogleMapURL { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Location { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? About { get; set; }
        public string? Currency { get; set; }
        public int TotalRatings { get; set; }
        public double Rating { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }     
        [NotMapped]
        public string? ImageSrc { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }

    public class BranchAvailability
    {
        [Key]
        public Guid BranchAvailabilityId { get; set; }
        public Guid BranchId { get; set; }
        public Branch? Branch { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string? MondayOpeningTime { get; set; }
        public string? TuesdayOpeningTime { get; set; }
        public string? WednesdayOpeningTime { get; set; }
        public string? ThursdayOpeningTime { get; set; }
        public string? FridayOpeningTime { get; set; }
        public string? SaturdayOpeningTime { get; set; }
        public string? SundayOpeningTime { get; set; }
        public string? MondayClosingTime { get; set; }
        public string? TuesdayClosingTime { get; set; }
        public string? WednesdayClosingTime { get; set; }
        public string? ThursdayClosingTime { get; set; }
        public string? FridayClosingTime { get; set; }
        public string? SaturdayClosingTime { get; set; }
        public string? SundayClosingTime { get; set; }
    }
    public class BranchEmployee
    {
        [Key]
        public Guid BranchEmployeeId { get; set; }
        public Branch? Branch { get; set; }
        public Guid BranchId { get; set; }        
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Designation { get; set; }
    }
    public class BranchImage
    {
        [Key]
        public Guid BranchImageId { get; set; }
        public Branch? Branch { get; set; }
        public Guid BranchId { get; set; }     
        public string? ImageName { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
    }
}
