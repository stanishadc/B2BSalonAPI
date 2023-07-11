using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class SubscriptionType
    {
        [Key]
        public Guid SubscriptionTypeId { get; set; }
        public string? SubscriptionName { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public string? PaymentLink { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class SubscriptionData
    {
        [Key]
        public Guid SubscriptionDataId { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }
        public string? SubscriptionText { get; set; }        
    }
}
