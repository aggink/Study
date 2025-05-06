namespace Study.Lab2.Logic.UnitTests.kinkiss1.DtoModels
{
    public class GoogleTranslateItemDto
    {
        public string TranslatedText { get; set; }
        public string OriginalText { get; set; }
        public int? Confidence { get; set; }
        public int? Index { get; set; }
    }

    public class GoogleTranslateSegmentDto
    {
        public List<GoogleTranslateItemDto> Items { get; set; }
    }

    public class GoogleTranslateResponseDto
    {
        public List<GoogleTranslateSegmentDto> Translations { get; set; }
        public string SourceLanguage { get; set; }
    }
}
