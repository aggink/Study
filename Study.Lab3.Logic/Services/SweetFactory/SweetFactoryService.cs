using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.SweetFactory;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Logic.Services.SweetFactory
{
    public sealed class SweetFactoryService : ISweetFactoryService
    {
        public async Task CreateOrUpdateSweetFactoryValidateAndThrowAsync(
        DataContext dataContext,
        Storage.Models.Sweets.SweetFactory sweetfactory,
        CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(sweetfactory.Name))
                throw new BusinessLogicException("Название фабрики не может быть пустым");

            if (string.IsNullOrWhiteSpace(sweetfactory.Address))
                throw new BusinessLogicException("Адрес фабрики не может быть пустым");
        }

        public async Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            Storage.Models.Sweets.SweetFactory sweetfactory,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.SweetFactories.AnyAsync(x => x.IsnSweetFactory == sweetfactory.IsnSweetFactory, cancellationToken))
                throw new BusinessLogicException(
                    $"Фабрики с идентификатором \"{sweetfactory.IsnSweetFactory}\" не существует");

            // Проверка на наличие фабрик 
            if (await dataContext.SweetProductions.AnyAsync(x => x.IsnSweetFactory == sweetfactory.IsnSweetFactory, cancellationToken))
                throw new BusinessLogicException(
                    "Невозможно удалить фабрику, так как у неё есть история производства сладостей");
        }
    }
}
