using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Museum;

namespace Study.Lab3.Logic.Services.Museum;

public sealed class MuseumExhibitService : IMuseumExhibitService
{
    public async Task CreateOrUpdateExhibitValidateAndThrowAsync(
        DataContext dataContext,
        MuseumExhibit exhibit,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(exhibit.Name))
            throw new BusinessLogicException("Название экспоната не может быть пустым");

        if (string.IsNullOrWhiteSpace(exhibit.Location))
            throw new BusinessLogicException("Местоположение экспоната не может быть пустым");

        if (string.IsNullOrWhiteSpace(exhibit.Status))
            throw new BusinessLogicException("Статус экспоната не может быть пустым");

        if (exhibit.EstimatedValue < 0)
            throw new BusinessLogicException("Оценочная стоимость не может быть отрицательной");

        if (exhibit.AcquisitionDate > DateTime.UtcNow)
            throw new BusinessLogicException("Дата приобретения не может быть в будущем");

        // Проверка уникальности названия
        if (await dataContext.MuseumExhibits.AnyAsync(
            x => x.Name == exhibit.Name && x.IsnMuseumExhibit != exhibit.IsnMuseumExhibit,
            cancellationToken))
            throw new BusinessLogicException($"Экспонат с названием \"{exhibit.Name}\" уже существует");

        // Проверка корректности статуса
        var validStatuses = new[] { "Выставлен", "В хранилище", "На реставрации", "В аренде" };
        if (!validStatuses.Contains(exhibit.Status))
            throw new BusinessLogicException($"Недопустимый статус экспоната. Допустимые статусы: {string.Join(", ", validStatuses)}");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MuseumExhibit exhibit,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.MuseumExhibits.AnyAsync(x => x.IsnMuseumExhibit == exhibit.IsnMuseumExhibit, cancellationToken))
            throw new BusinessLogicException($"Экспонат с идентификатором \"{exhibit.IsnMuseumExhibit}\" не существует");

        // Проверка, что нет связанных деталей
        if (await dataContext.MuseumExhibitDetails.AnyAsync(x => x.IsnMuseumExhibit == exhibit.IsnMuseumExhibit, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить экспонат, так как у него есть детальная информация");

        // Проверка статуса
        if (exhibit.Status == "В аренде")
            throw new BusinessLogicException("Невозможно удалить экспонат, который находится в аренде");
    }

    public async Task CreateOrUpdateExhibitDetailsValidateAndThrowAsync(
        DataContext dataContext,
        MuseumExhibitDetails exhibitDetails,
        CancellationToken cancellationToken = default)
    {
        // Проверка существования экспоната
        if (!await dataContext.MuseumExhibits.AnyAsync(x => x.IsnMuseumExhibit == exhibitDetails.IsnMuseumExhibit, cancellationToken))
            throw new BusinessLogicException($"Экспонат с идентификатором \"{exhibitDetails.IsnMuseumExhibit}\" не существует");

        // Проверка уникальности деталей для экспоната (один к одному)
        if (await dataContext.MuseumExhibitDetails.AnyAsync(
            x => x.IsnMuseumExhibit == exhibitDetails.IsnMuseumExhibit && 
                 x.IsnMuseumExhibitDetails != exhibitDetails.IsnMuseumExhibitDetails,
            cancellationToken))
            throw new BusinessLogicException("У экспоната уже есть детальная информация");

        // Проверка года создания
        if (exhibitDetails.CreationYear.HasValue)
        {
            if (exhibitDetails.CreationYear > DateTime.UtcNow.Year)
                throw new BusinessLogicException("Год создания не может быть в будущем");

            if (exhibitDetails.CreationYear < -10000)
                throw new BusinessLogicException("Год создания не может быть раньше 10000 г. до н.э.");
        }

        // Проверка веса
        if (exhibitDetails.Weight.HasValue && exhibitDetails.Weight < 0)
            throw new BusinessLogicException("Вес не может быть отрицательным");

        // Проверка состояния
        if (!string.IsNullOrWhiteSpace(exhibitDetails.Condition))
        {
            var validConditions = new[] { "Отличное", "Хорошее", "Удовлетворительное", "Требует реставрации", "Критическое" };
            if (!validConditions.Contains(exhibitDetails.Condition))
                throw new BusinessLogicException($"Недопустимое состояние. Допустимые: {string.Join(", ", validConditions)}");
        }
    }
}
