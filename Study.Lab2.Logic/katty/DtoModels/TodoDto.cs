namespace Study.Lab2.Logic.katty.DtoModels;

public class TodoDto
{
    public int UserId { get; }

    public int Id { get; }

    public string Title { get; }

    public bool Completed { get; }

    public TodoDto(int userId, int id, string title, bool completed)
    {
        UserId = userId;
        Id = id;
        Title = title ?? string.Empty;
        Completed = completed;
    }
}