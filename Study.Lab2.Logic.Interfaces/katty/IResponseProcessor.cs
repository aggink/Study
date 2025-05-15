namespace Study.Lab2.Logic.Interfaces.katty;

public interface IResponseProcessor
{
    bool IsSuccessResponse<T>(string response);
    string ProcessResponse<T>(string response);
}