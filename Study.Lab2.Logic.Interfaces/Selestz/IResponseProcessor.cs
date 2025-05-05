namespace Study.Lab2.Logic.Interfaces.Selestz;

public interface IResponseProcessor
{
    T FormatJsonResponse<T>(string jsonResponse) where T : class;
    bool HasError(string response);
    string ExtractErrorMessage(string response);
}