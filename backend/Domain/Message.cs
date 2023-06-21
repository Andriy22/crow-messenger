namespace Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public virtual HashSet<Attachment> Attachments { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual required AppUser Sender { get; set; }
        public virtual required AppUser InitialSender { get; set; }
        public virtual required HashSet<ChatBase> Chat { get; set; }
        public Message()
        {
            Attachments = new HashSet<Attachment>();
        }
    }
}