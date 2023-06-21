namespace Domain
{
    public class GroupChat : ChatBase
    {
        public HashSet<AppUser> Participants { get; set; }
        public GroupChat()
        {
            Participants = new HashSet<AppUser>();
        }
    }
}
