using System.Text.RegularExpressions;
using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;

namespace Study.Lab3.Logic.Services.TravelAgency;

public sealed class HotelService : IHotelService
{
    public async Task CreateOrUpdateHotelValidateAndThrowAsync(
        DataContext dataContext,
        Hotel hotel,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(hotel.Name))
            throw new BusinessLogicException("Название отеля не может быть пустым");

        if (string.IsNullOrWhiteSpace(hotel.Address))
            throw new BusinessLogicException("Адрес отеля не может быть пустым");

        if (string.IsNullOrWhiteSpace(hotel.Country))
            throw new BusinessLogicException("Страна не может быть пустой");

        if (string.IsNullOrWhiteSpace(hotel.City))
            throw new BusinessLogicException("Город не может быть пустым");

        if (hotel.PricePerNight <= 0)
            throw new BusinessLogicException("Цена за ночь должна быть положительным числом");

        if (!string.IsNullOrWhiteSpace(hotel.Email) && !IsValidEmail(hotel.Email))
            throw new BusinessLogicException("Некорректный формат email");

        if (!string.IsNullOrWhiteSpace(hotel.Phone) && !IsValidPhone(hotel.Phone))
            throw new BusinessLogicException("Некорректный формат телефона");

        if (await dataContext.Hotels.AnyAsync(
            x => x.Name == hotel.Name &&
                 x.Address == hotel.Address &&
                 x.IsnHotel != hotel.IsnHotel,
            cancellationToken))
            throw new BusinessLogicException("Отель с таким названием и адресом уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Hotel hotel,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Hotels.AnyAsync(x => x.IsnHotel == hotel.IsnHotel, cancellationToken))
            throw new BusinessLogicException($"Отель с идентификатором \"{hotel.IsnHotel}\" не существует");
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private static bool IsValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^[\d\s\(\)\-\+]+$");
    }
}
