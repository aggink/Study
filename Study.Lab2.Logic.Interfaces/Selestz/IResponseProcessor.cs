namespace Study.Lab2.Logic.Interfaces.Selestz;

public interface IResponseProcessor
{
    string FormatJsonResponse(string jsonResponse);
    bool HasError(string response);
    string ExtractErrorMessage(string response);
}