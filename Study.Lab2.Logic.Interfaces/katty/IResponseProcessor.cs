namespace Study.Lab2.Logic.Interfaces.katty;

public interface IResponseProcessor
{
    string ProcessResponse(string response);

    bool IsSuccessResponse(string response);
}
