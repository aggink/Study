namespace Study.Lab2.Logic.Interfaces.mansurgh.DtoModels;

public sealed record BoredActivityDto
{
    public string Activity { get; init; }
    public string Type { get; init; }
    public int Participants { get; init; }
    public double Price { get; init; }
}
