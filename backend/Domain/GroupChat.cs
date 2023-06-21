namespace Domain
{
    public class GroupChat : ChatBase
    {
        public GroupChat()
        {
            Participants = new HashSet<AppUser>();
        }
        public HashSet<AppUser> Participants { get; set; }
    }
}
