namespace Chat.Domain.Entities
{
    public class Message
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Content { get; private set; }
        public DateTime Created { get; private set; }

        public Message(string username, string content)
        {
            Username = username;
            Content = content;
            Created = DateTime.Now;
        }
    }
}
