using System.Text;
using System.Text.Json;
using Study.Lab2.Logic.Interfaces.neijrr;

namespace Study.Lab2.Logic.neijrr;

public class Post : IPost
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public Post(int id, int? userId, string title, string body)
    {
        Id = id;
        UserId = userId;
        Title = title;
        Body = body;
    }

    public Post(JsonDocument json)
    {
        var root = json.RootElement;

        if (!root.TryGetProperty("id", out var idProp))
            throw new KeyNotFoundException("Отсутствует поле id");
        if (!idProp.TryGetInt32(out var id))
            throw new ArgumentException("id не является числом");
        Id = id;

        if (root.TryGetProperty("userId", out var userIdProp) && userIdProp.TryGetInt32(out var userId))
            UserId = userId;
        else
            UserId = null;

        if (root.TryGetProperty("title", out var titleProp))
            Title = titleProp.ToString();
        else
            Title = null;

        if (root.TryGetProperty("body", out var bodyProp))
            Body = bodyProp.ToString();
        else
            Body = null;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("{");
        if (UserId is not null)
        {
            sb.Append("  \"userId\": ");
            sb.Append(UserId);
            sb.AppendLine(",");
        }
        sb.Append("  \"id\": ");
        sb.Append(Id);
        sb.AppendLine(",");
        if (!(Title is null || Title.Length == 0))
        {
            sb.Append("  \"title\": \"");
            sb.Append(Title.Replace("\n", "\\n"));
            sb.AppendLine("\",");
        }
        if (!(Body is null || Body.Length == 0))
        {
            sb.Append("  \"body\": \"");
            sb.Append(Body.Replace("\n", "\\n"));
            sb.AppendLine("\"");
        }
        sb.Append('}');
        return sb.ToString();
    }
}
