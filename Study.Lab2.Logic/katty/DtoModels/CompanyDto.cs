namespace Study.Lab2.Logic.katty.DtoModels;

public class CompanyDto
{
    public string Name { get; }

    public string CatchPhrase { get; }

    public string Bs { get; }

    public CompanyDto(string name, string catchPhrase, string bs)
    {
        Name = name ?? string.Empty;
        CatchPhrase = catchPhrase ?? string.Empty;
        Bs = bs ?? string.Empty;
    }
}
