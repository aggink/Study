using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;

namespace Study.Lab3.Logic.Services.Workshop;

public sealed class MasterService : IMasterService
{
    public async Task CreateOrUpdateMasterValidateAndThrowAsync(
        DataContext dataContext,
        Master master,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(master.Name))
            throw new BusinessLogicException("Имя мастера не может быть пустым");

        if (string.IsNullOrWhiteSpace(master.Email))
            throw new BusinessLogicException("Email мастера не может быть пустым");

        if (string.IsNullOrWhiteSpace(master.Phone))
            throw new BusinessLogicException("Телефон мастера не может быть пустым");

        if (string.IsNullOrWhiteSpace(master.Specialization))
            throw new BusinessLogicException("Специализация мастера не может быть пустой");

        // Проверка уникальности email
        if (await dataContext.Masters.AnyAsync(x =>
            x.Email.ToLower() == master.Email.ToLower() &&
            x.IsnMaster != master.IsnMaster,
            cancellationToken))
            throw new BusinessLogicException($"Мастер с email \"{master.Email}\" уже существует");

        // Проверка уникальности телефона
        if (await dataContext.Masters.AnyAsync(x =>
            x.Phone == master.Phone &&
            x.IsnMaster != master.IsnMaster,
            cancellationToken))
            throw new BusinessLogicException($"Мастер с телефоном \"{master.Phone}\" уже существует");

        // Проверка формата email
        if (!IsValidEmail(master.Email))
            throw new BusinessLogicException("Неверный формат email");

        // Проверка формата телефона
        if (!IsValidPhone(master.Phone))
            throw new BusinessLogicException("Неверный формат телефона");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Master master,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Masters.AnyAsync(x => x.IsnMaster == master.IsnMaster, cancellationToken))
            throw new BusinessLogicException($"Мастер с идентификатором \"{master.IsnMaster}\" не существует");

        if (await dataContext.ServiceOrders.AnyAsync(x => x.IsnMaster == master.IsnMaster, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить мастера, так как за ним закреплены заказы");
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
        return phone.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == '(' || c == ')' || c == ' ') 
               && phone.Any(char.IsDigit);
    }
}