using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Services.BeautySalon;

public sealed class BeautyClientService : IBeautyClientService
{
    public async Task CreateOrUpdateBeautyClientValidateAndThrowAsync(
        DataContext dataContext,
        BeautyClient beautyclient,
        CancellationToken cancellationToken = default)
    {
        /// Проверка правильности ввода имени клиента
        if (string.IsNullOrWhiteSpace(beautyclient.FirstName) || (beautyclient.FirstName.Length > ModelConstants.BeautyClient.FirstName))
        {
            throw new BusinessLogicException($"Имя клиента не может быть пустым и не может превышать {ModelConstants.BeautyClient.FirstName} символов!");
        }

        /// Проверка правильности ввода фамилии клиента
        if (string.IsNullOrWhiteSpace(beautyclient.LastName) || (beautyclient.LastName.Length > ModelConstants.BeautyClient.LastName))
        {
            throw new BusinessLogicException($"Фамилия клиента не может быть пустой и не может превышать {ModelConstants.BeautyClient.LastName} символов!");
        }

        /// Проверка правильности ввода номера телефона клиента
        if (string.IsNullOrWhiteSpace(beautyclient.PhoneNumber) || (beautyclient.PhoneNumber.Length > ModelConstants.BeautyClient.PhoneNumber))
        {
            throw new BusinessLogicException($"Телефон клиента не может быть пустым ине может превышать {ModelConstants.BeautyClient.PhoneNumber} символов!!");
        }

        /// Проверка правильности ввода электронной почты клиента клиента
        if (string.IsNullOrWhiteSpace(beautyclient.EmailAddress) || (beautyclient.EmailAddress.Length > ModelConstants.BeautyClient.EmailAddress))
        {
            throw new BusinessLogicException($"Электронная почта клиента не может быть пустой и не может превышать {ModelConstants.BeautyClient.EmailAddress} символов!");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        BeautyClient beautyclient,
        CancellationToken cancellationToken = default)
    {
        bool hasApointments = await dataContext.BeautyAppointments.AnyAsync(x => x.IsnBeautyClient == beautyclient.IsnClient, cancellationToken);
        if (hasApointments)
        {
            throw new BusinessLogicException("Невозможно удалить клиента, у которого есть связанные записи на услуги!");
        }
    }
}