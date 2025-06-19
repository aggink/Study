using System.Text.RegularExpressions;
using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;

namespace Study.Lab3.Logic.Services.CarService;

public sealed class OwnerService : IOwnerService
{
    public async Task CreateOrUpdateOwnerValidateAndThrowAsync(DataContext dataContext, Owner owner,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(owner.FirstName))
            throw new BusinessLogicException("Имя не может быть пустым");
        
        if (string.IsNullOrWhiteSpace(owner.SecondName))
            throw new BusinessLogicException("Фамилия не может быть пустой");
        
        if (string.IsNullOrWhiteSpace(owner.PhoneNumber))
            throw new BusinessLogicException("Номер телефона не может быть пустым");
        
        if (string.IsNullOrWhiteSpace(owner.Email))
            throw new BusinessLogicException("Эмаил не может быть пустым");
        
        // Проверка формата телефона
        if (!Regex.IsMatch(owner.PhoneNumber, @"^[\d\s\+\-\(\)]+$"))
            throw new BusinessLogicException("Неверный формат номера телефона");

        // Проверка формата email
        if (!Regex.IsMatch(owner.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new BusinessLogicException("Неверный формат email");

        // Проверка на дубликат по телефону
        if (await dataContext.Owners.AnyAsync(
                x => x.PhoneNumber == owner.PhoneNumber && x.IsnOwner != owner.IsnOwner,
                cancellationToken))
            throw new BusinessLogicException($"Владелец с номером телефона \"{owner.PhoneNumber}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext, 
        Owner owner, 
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Cars.AnyAsync(x => x.IsnOwner == owner.IsnOwner, cancellationToken))
            throw new BusinessLogicException($"Не возможно удалить пользователя т.к. у него зарегестрирован автомобиль");
    }
}