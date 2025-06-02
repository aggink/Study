using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.SweetFactory;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Services.Sweets
{
    internal class SweetProductionService : ISweetProductionService
    {
        public async Task CreateOrUpdateSweetProductionValidateAndThrowAsync(
        DataContext dataContext,
            SweetProduction sweetproduction,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.Sweets.AnyAsync(x => x.ID == sweetproduction.SweetID, cancellationToken))
                throw new BusinessLogicException(
                    $" Сладости с идентификатором \"{sweetproduction.SweetID}\" не существует");

            if (!await dataContext.SweetFactories.AnyAsync(x => x.ID == sweetproduction.SweetFactoryID, cancellationToken))
                throw new BusinessLogicException(
                    $"Фабрики с идентификатором \"{sweetproduction.SweetFactoryID}\" не существует");

            if (await dataContext.SweetProductions.AnyAsync(x => x.SweetFactoryID == sweetproduction.SweetFactoryID && x.SweetID == sweetproduction.SweetID, cancellationToken))
                throw new BusinessLogicException(
                    "Запись уже существует, невозможно завести запись");
        }

        public async Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            SweetProduction sweetproduction,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.SweetProductions.AnyAsync(x => x.SweetFactoryID == sweetproduction.SweetFactoryID && x.SweetID == sweetproduction.SweetID, cancellationToken))
                throw new BusinessLogicException(
                    "Записи не существует, невозможно завести запись");
        }
    }
}
