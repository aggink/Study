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
    public sealed class SweetService : ISweetService
    {
        public async Task CreateOrUpdateSweetValidateAndThrowAsync(
        DataContext dataContext,
        Sweet sweet,
        CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(sweet.Name))
                throw new BusinessLogicException("Название сладости не может быть пустым");

            if (string.IsNullOrWhiteSpace(sweet.Ingredients))
                throw new BusinessLogicException("Поле Ингридиенты у сладости не может быть пустым");
        }

        public async Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            Sweet sweet,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.Sweets.AnyAsync(x => x.IsnSweet == sweet.IsnSweet, cancellationToken))
                throw new BusinessLogicException(
                    $"Сладости с идентификатором \"{sweet.IsnSweet}\" не существует");

            if (await dataContext.SweetProductions.AnyAsync(x => x.IsnSweet == sweet.IsnSweet, cancellationToken))
                throw new BusinessLogicException(
                    "Невозможно удалить фабрику, так как у неё есть история производства сладостей");
        }
    }
}
