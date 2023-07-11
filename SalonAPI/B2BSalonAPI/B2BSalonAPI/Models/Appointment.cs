using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class Appointment
    {
        [Key]
        public Guid AppointmentId { get; set; }
        public string? AppointmentNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? AppointmentTime { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Duration { get; set; }
        public string? UserServices { get; set; }
        public Guid Id { get; set; }
        public User? User { get; set; }
        public string? BookingStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? ModeOfPayment { get; set; }
        public string? PaymentPlace { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public double Tax { get; set; }
        public string? Review { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid BranchEmployeeId { get; set; }
        public BranchEmployee? BranchEmployee { get; set; }        
    }
    public class AppointmentService
    {
        [Key]
        public Guid AppointmentServiceId { get; set; }
        public Guid ServiceId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public double Price { get; set; }
        public string? Duration { get; set; }
        public Guid AppointmentId { get; set; }
        public Appointment? Appointments { get; set; }
    }
    public class Timings
    {
        public bool IsOpened { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Day { get; set; }
        public int DayNo { get; set; }
        public string[]? Intervals { get; set; }
    }
    public class GetTimings
    {
        public string? SearchDate { get; set; }
        public int BranchId { get; set; }
    }
}
