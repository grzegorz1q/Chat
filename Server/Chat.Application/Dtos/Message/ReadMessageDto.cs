namespace Chat.Application.Dtos.Message
{
    public record ReadMessageDto(int Id, string Username, string Content, DateTime Created);
}
