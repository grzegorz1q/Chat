namespace Chat.Domain.Entities
{
    public class Message
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public DateTime Created { get; private set; }
        public int UserId {  get; private set; }
        public User User { get; private set; } = default!;
        public Message(string content)
        {
            Content = content;
            Created = DateTime.Now;
        }
    }
}
