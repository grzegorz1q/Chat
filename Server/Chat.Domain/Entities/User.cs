namespace Chat.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public ICollection<Message> Messages { get; private set; } = default!;
        public User(string username, string passwordHash) 
        {
            Username = username;
            PasswordHash = passwordHash;
        }
    }
}
