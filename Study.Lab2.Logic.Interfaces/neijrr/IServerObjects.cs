namespace Study.Lab2.Logic.Interfaces.neijrr;

public interface IPost
{
    int Id { get; set; }

    int? UserId { get; set; }

    string Title { get; set; }

    string Body { get; set; }
}
