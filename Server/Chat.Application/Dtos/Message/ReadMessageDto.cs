namespace Chat.Application.Dtos.Message
{
    public record ReadMessageDto(int Id, int UserId, string Username, string Content, DateTime Created);
}
