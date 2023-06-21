namespace Domain
{
    public class PrivateChat : ChatBase
    {
        public PrivateChat()
        {
            Participants = new HashSet<AppUser>();
        }
        public virtual HashSet<AppUser> Participants { get; set; }
    }
}
