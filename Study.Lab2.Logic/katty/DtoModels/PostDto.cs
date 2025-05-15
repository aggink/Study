namespace Study.Lab2.Logic.katty.DtoModels;

public class PostDto
{
    public int UserId { get; }

    public int Id { get; }

    public string Title { get; }

    public string Body { get; }

    public PostDto(int userId, int id, string title, string body)
    {
        UserId = userId;
        Id = id;
        Title = title ?? string.Empty;
        Body = body ?? string.Empty;
    }
}