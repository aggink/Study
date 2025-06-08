using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Study.Lab3.Logic.Interfaces.Services.Sweets;
=======
using Study.Lab3.Logic.Interfaces.Services.SweetFactory;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Study.Lab3.Logic.Services.Sweets
=======
namespace Study.Lab3.Logic.Services.SweetFactory
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
{
    public sealed class SweetProductionService : ISweetProductionService
    {
        public async Task CreateOrUpdateSweetProductionValidateAndThrowAsync(
            DataContext dataContext,
            SweetProduction sweetproduction,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.Sweets.AnyAsync(x => x.IsnSweet == sweetproduction.IsnSweet, cancellationToken))
                throw new BusinessLogicException(
                    $" Сладости с идентификатором \"{sweetproduction.IsnSweet}\" не существует");

            if (!await dataContext.SweetFactories.AnyAsync(x => x.IsnSweetFactory == sweetproduction.IsnSweetFactory, cancellationToken))
                throw new BusinessLogicException(
                    $"Фабрики с идентификатором \"{sweetproduction.IsnSweetFactory}\" не существует");

            if (await dataContext.SweetProductions.AnyAsync(x => x.IsnSweetFactory == sweetproduction.IsnSweetFactory && x.IsnSweet == sweetproduction.IsnSweet, cancellationToken))
                throw new BusinessLogicException(
                    "Запись уже существует, невозможно завести запись");
        }

        public async Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            SweetProduction sweetproduction,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.SweetProductions.AnyAsync(x => x.IsnSweetFactory == sweetproduction.IsnSweetFactory && x.IsnSweet == sweetproduction.IsnSweet, cancellationToken))
                throw new BusinessLogicException(
                    "Записи не существует, невозможно завести запись");
        }
    }
}
