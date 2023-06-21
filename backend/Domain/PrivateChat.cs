namespace Domain
{
    public class PrivateChat : ChatBase
    {
        public virtual HashSet<AppUser> Participants { get; set; }
        public PrivateChat()
        {
            Participants = new HashSet<AppUser>();
        }
    }
}
