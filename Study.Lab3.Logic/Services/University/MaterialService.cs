using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class MaterialService : IMaterialService
{
    public async Task CreateOrUpdateMaterialValidateAndThrowAsync(
        DataContext dataContext,
        Material material,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == material.IsnSubject, cancellationToken))
            throw new BusinessLogicException($"Предмет с идентификатором \"{material.IsnSubject}\" не существует");

        if (string.IsNullOrWhiteSpace(material.Title))
            throw new BusinessLogicException("Название материала не может быть пустым");

        if (string.IsNullOrWhiteSpace(material.Type))
            throw new BusinessLogicException("Тип материала не может быть пустым");

        if (string.IsNullOrWhiteSpace(material.Url))
            throw new BusinessLogicException("URL материала не может быть пустым");

        if (await dataContext.Materials.AnyAsync(
                x => x.IsnSubject == material.IsnSubject &&
                     x.Title == material.Title &&
                     x.IsnMaterial != material.IsnMaterial,
                cancellationToken))
            throw new BusinessLogicException(
                $"Материал с названием \"{material.Title}\" уже существует для данного предмета");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Material material,
        CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}