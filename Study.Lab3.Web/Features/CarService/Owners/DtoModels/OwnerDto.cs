namespace Study.Lab3.Web.Features.CarService.Owners.DtoModels;

public sealed record OwnerDto
{
    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    public Guid IsnOwner { get; init; }
 
    /// <summary>
    /// Имя владельца
    /// </summary>
    public string FirstName { get; init; }
 
    /// <summary>
    /// Фамилия владельца
    /// </summary>
    public string SecondName { get; init; }
 
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; init; }
 
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }
 
    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; init; }
}