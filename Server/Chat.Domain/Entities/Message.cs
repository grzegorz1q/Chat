namespace Chat.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
