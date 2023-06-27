using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public required string Nickname { get; set; }
        public required string Bio { get; set; }
        public required DateTime RegistrationDate { get; set; }
        public required DateTime LastLoginDate { get; set; }
        public Attachment? ProfilePicture { get; set; }
        public bool AllowForward { get; set; }
        public virtual ICollection<AuthorizedDevice> AuthorizedDevices { get; set; }

        public AppUser()
        {
            AuthorizedDevices = new HashSet<AuthorizedDevice>();
        }
    }
}