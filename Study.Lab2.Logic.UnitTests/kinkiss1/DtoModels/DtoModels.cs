namespace Study.Lab2.Logic.UnitTests.kinkiss1.DtoModels
{
    internal class CatFactResponseDto
    {
        public string Fact { get; set; }
        public int Length { get; set; }
    }

    internal class CatFactTranslatedResponseDto : CatFactResponseDto
    {
        public string Translate { get; set; }
    }

    internal class KanyeRestResponseDto
    {
        public string Quote { get; set; }
    }

    internal class KanyeRestTranslatedResponseDto : KanyeRestResponseDto
    {
        public string Translate { get; set; }
    }

    // Новые классы для ответа Google Translate API
    internal class GoogleTranslateItemDto
    {
        public string TranslatedText { get; set; }
        public string OriginalText { get; set; }
        public int? Confidence { get; set; }
        public int? Index { get; set; }
    }

    internal class GoogleTranslateSegmentDto
    {
        public List<GoogleTranslateItemDto> Items { get; set; }
    }

    internal class GoogleTranslateResponseDto
    {
        public List<GoogleTranslateSegmentDto> Translations { get; set; }
        public string SourceLanguage { get; set; }
    }

}
