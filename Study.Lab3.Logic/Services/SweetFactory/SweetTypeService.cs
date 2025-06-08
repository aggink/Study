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
    public sealed class SweetTypeService : ISweetTypeService
    {
        public async Task CreateOrUpdateSweetTypeValidateAndThrowAsync(
        DataContext dataContext,
        SweetType sweettype,
        CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(sweettype.Name))
                throw new BusinessLogicException("Название сладости не может быть пустым");
        }

        public async Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            SweetType sweettype,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.SweetTypes.AnyAsync(x => x.IsnSweetType == sweettype.IsnSweetType, cancellationToken))
                throw new BusinessLogicException(
                    $"Сладости с идентификатором \"{sweettype.IsnSweetType}\" не существует");

            if (await dataContext.Sweets.AnyAsync(x => x.IsnSweetType == sweettype.IsnSweetType, cancellationToken))
                throw new BusinessLogicException(
                    "Невозможно удалить сладость, так как у неё есть история создания");
        }
    }
}
