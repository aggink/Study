namespace Study.Lab2.Logic.katty.DtoModels;

public class UserDto
{
    public int Id { get; }

    public string Name { get; }

    public string Username { get; }

    public string Email { get; }

    public AddressDto Address { get; }

    public string Phone { get; }

    public string Website { get; }

    public CompanyDto Company { get; }

    public UserDto(
        int id,
        string name,
        string username,
        string email,
        AddressDto address,
        string phone,
        string website,
        CompanyDto company)
    {
        Id = id;
        Name = name ?? string.Empty;
        Username = username ?? string.Empty;
        Email = email ?? string.Empty;
        Address = address;
        Phone = phone ?? string.Empty;
        Website = website ?? string.Empty;
        Company = company;
    }
}