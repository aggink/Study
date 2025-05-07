namespace Study.Lab2.Logic.Logic.kinkiss1.DtoModels
{
    public class MainGoogleTranslateDto
    {
        public string TranslatedText { get; init; }
        public string OriginalText { get; init; }
        public int? Confidence { get; init; }
        public int? Index { get; init; }
    }

    public class GoogleTranslateSegmentDto
    {
        public List<MainGoogleTranslateDto> Items { get; init; }
    }

    public class GoogleTranslateResponseDto
    {
        public List<GoogleTranslateSegmentDto> Translations { get; init; }
        public string SourceLanguage { get; init; }
    }
}