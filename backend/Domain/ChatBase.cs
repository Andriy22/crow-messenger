namespace Domain
{
    public class ChatBase
    {
        public int Id { get; set; }
        public HashSet<Message> Messages { get; set; }
        public ChatBase()
        {
            Messages = new HashSet<Message>();
        }
    }
}