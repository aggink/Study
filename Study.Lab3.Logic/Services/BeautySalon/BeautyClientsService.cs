using CoreLib.Common.Extensions;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Services.BeautySalon;

public sealed class BeautyClientsService : IBeautyClientsService
{
    public async Task CreateOrUpdateBeautyClientValidate(
        DataContext dataContext,
        BeautyClient beautyclient,
        CancellationToken cancellationToken = default)
    {
        /// Проверка правильности ввода имени клиента
        if (string.IsNullOrWhiteSpace(beautyclient.FirstName))
        {
            throw new BusinessLogicException($"Имя клиента не может быть пустым!");
        }

        if (beautyclient.FirstName.Length > ModelConstants.BeautyClient.FirstName)
        {
            throw new BusinessLogicException($"Имя клиента не может превышать {ModelConstants.BeautyClient.FirstName} символов!");
        }

        /// Проверка правильности ввода фамилии клиента
        if (string.IsNullOrWhiteSpace(beautyclient.LastName))
        {
            throw new BusinessLogicException($"Фамилия клиента не может быть пустой!");
        }

        if (beautyclient.LastName.Length > ModelConstants.BeautyClient.LastName)
        {
            throw new BusinessLogicException($"Фамилия клиента не может превышать {ModelConstants.BeautyClient.LastName} символов!");
        }

        /// Проверка правильности ввода номера телефона клиента
        if (string.IsNullOrWhiteSpace(beautyclient.PhoneNumber))
        {
            throw new BusinessLogicException($"Телефон клиента не может быть пустым!");
        }

        if (beautyclient.PhoneNumber.Length > ModelConstants.BeautyClient.PhoneNumber)
        {
            throw new BusinessLogicException($"Телефон клиента не может превышать {ModelConstants.BeautyClient.PhoneNumber} символов!");
        }

        /// Проверка правильности ввода электронной почты клиента клиента
        if (string.IsNullOrWhiteSpace(beautyclient.EmailAddress))
        {
            throw new BusinessLogicException($"Электронная почта клиента не может быть пустой!");
        }

        if (beautyclient.EmailAddress.Length > ModelConstants.BeautyClient.EmailAddress)
        {
            throw new BusinessLogicException($"Телефон клиента не может превышать {ModelConstants.BeautyClient.EmailAddress} символов!");
        }
    }

    public async Task DeleteBeautyClientValidate(
        DataContext dataContext,
        BeautyClient beautyclient,
        CancellationToken cancellationToken = default)
    {
        return;
    }
}