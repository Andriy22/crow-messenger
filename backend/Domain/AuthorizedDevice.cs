using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class AuthorizedDevice
    {
        public int Id { get; set; }
        public string? DeviceName { get; set; }
        public required string DeviceId { get; set; }
        public string? DeviceType { get; set; }
        public string? DeviceOS { get; set; }
        public string? DeviceOSVersion { get; set; }
        public string? DeviceAppVersion { get; set; }
        public string? DeviceAppBuildNumber { get; set; }
        public required string SecurityTokenSignature { get; set; }
        public required DateTime LastLoginDate { get; set; }
        public required DateTime CreatedDate { get; set; }
        [ForeignKey("User")] public required string UserId { get; set; }
        public virtual required AppUser User { get; set; }
    }
}