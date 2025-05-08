namespace Study.Lab2.Logic.kinkiss1.DtoModels;

public class GoogleTranslateResponseDto
{
    public List<GoogleTranslateSegmentDto> Translations { get; init; }
    public string SourceLanguage { get; init; }
}

public class GoogleTranslateItemDto
{
    public string TranslatedText { get; init; }
    public string OriginalText { get; init; }
    public int? Confidence { get; init; }
    public int? Index { get; init; }
}

public class GoogleTranslateSegmentDto
{
    public List<GoogleTranslateItemDto> Items { get; init; }
}