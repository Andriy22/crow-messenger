namespace Domain
{
    public class ChatBase
    {
        public ChatBase()
        {
            Messages = new HashSet<Message>();
        }
        public int Id { get; set; }
        public HashSet<Message> Messages { get; set; }
    }
}