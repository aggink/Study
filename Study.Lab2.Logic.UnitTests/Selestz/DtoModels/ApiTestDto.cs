using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.Selestz.DtoModels;
internal sealed record ApiTestDto
{
    public string Name { get; init; }
    public int Age { get; init; }
}