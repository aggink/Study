public record CreateScientificWorkDto
{
    public Guid IsnStudent { get; init; }
    public Guid IsnSubject { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int PageCount { get; init; }
    public DateTime PublicationDate { get; init; }
    public bool IsPublished { get; init; }
}