using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Dormitory.Residents.DtoModels;

public sealed record CreateDormitoryResidentDto
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; init; } = string.Empty;

    [StringLength(50)]
    public string? MiddleName { get; init; }

    [Required]
    [StringLength(20)]
    public string StudentId { get; init; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string StudentGroup { get; init; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; init; }

    [StringLength(20)]
    public string? PhoneNumber { get; init; }

    [StringLength(100)]
    [EmailAddress]
    public string? Email { get; init; }

    [Required]
    public DateTime CheckInDate { get; init; }

    public DateTime? PlannedCheckOutDate { get; init; }

    [StringLength(500)]
    public string? Notes { get; init; }
}
