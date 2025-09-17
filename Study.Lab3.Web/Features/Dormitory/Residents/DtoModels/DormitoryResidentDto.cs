namespace Study.Lab3.Web.Features.Dormitory.Residents.DtoModels;

public sealed record DormitoryResidentDto
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string MiddleName { get; init; }
    public string StudentId { get; init; } = string.Empty;
    public string StudentGroup { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public DateTime CheckInDate { get; init; }
    public DateTime? PlannedCheckOutDate { get; init; }
    public DateTime? ActualCheckOutDate { get; init; }
    public string Notes { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
