using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.SweetFactory;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;

namespace Study.Lab3.Logic.Services.SweetFactory;

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
