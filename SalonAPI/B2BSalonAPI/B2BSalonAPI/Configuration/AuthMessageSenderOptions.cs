namespace B2BSalonAPI.Configuration
{
    public class AuthMessageSenderOptions
    {
        public string? SendGridKey { get; set; }
    }
    public class SendGridSettings
    {
        public string ApiKey { get; set; }
        public string FromEmail { get; set; }
        public string EmailName { get; set; }
    }
}
