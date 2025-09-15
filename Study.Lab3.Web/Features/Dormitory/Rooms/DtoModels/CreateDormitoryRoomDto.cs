using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Dormitory.Rooms.DtoModels;

public sealed record CreateDormitoryRoomDto
{
    [Required]
    [StringLength(10)]
    public string RoomNumber { get; init; } = string.Empty;

    [Range(1, 50)]
    public int Floor { get; init; }

    [Range(5.0, 100.0)]
    public double Area { get; init; }

    [Range(1, 6)]
    public int MaxOccupants { get; init; }

    [Range(0, 50000)]
    public decimal MonthlyRent { get; init; }

    public bool HasBalcony { get; init; }
    public bool HasPrivateBathroom { get; init; }

    [StringLength(500)]
    public string? Description { get; init; }
}
