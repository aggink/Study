namespace Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;

public sealed class StudentNoteWithDetailsDto
{
    public Guid IsnNote { get; init; }
    public Guid IsnStudent { get; init; }
    public string StudentFullName { get; init; }
    public string Text { get; init; }
}