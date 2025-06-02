using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.chirique_online.DtoModels;

public class ErrorResponseDto
{
    public string Error { get; set; }
    public string ErrorCode { get; set; }
}