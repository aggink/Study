using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;

namespace Study.Lab3.Logic.Services.TravelAgency;

public sealed class TourService : ITourService
{
    public async Task CreateOrUpdateTourValidateAndThrowAsync(
        DataContext dataContext,
        Tour tour,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(tour.Name))
            throw new BusinessLogicException("Название тура не может быть пустым");

        if (string.IsNullOrWhiteSpace(tour.Country))
            throw new BusinessLogicException("Страна назначения не может быть пустой");

        if (string.IsNullOrWhiteSpace(tour.City))
            throw new BusinessLogicException("Город назначения не может быть пустым");

        if (tour.Price <= 0)
            throw new BusinessLogicException("Цена тура должна быть положительным числом");

        if (tour.Duration <= 0)
            throw new BusinessLogicException("Продолжительность тура должна быть положительным числом");

        if (tour.MaxParticipants <= 0)
            throw new BusinessLogicException("Максимальное количество участников должно быть положительным числом");

        if (tour.StartDate >= tour.EndDate)
            throw new BusinessLogicException("Дата начала тура должна быть раньше даты окончания");

        if (tour.StartDate < DateTime.Today)
            throw new BusinessLogicException("Дата начала тура не может быть в прошлом");

        var daysDifference = (tour.EndDate - tour.StartDate).Days + 1;
        if (daysDifference != tour.Duration)
            throw new BusinessLogicException("Продолжительность тура не соответствует разности между датами начала и окончания");

        if (await dataContext.Tours.AnyAsync(
            x => x.Name == tour.Name &&
                 x.Country == tour.Country &&
                 x.City == tour.City &&
                 x.StartDate == tour.StartDate &&
                 x.IsnTour != tour.IsnTour,
            cancellationToken))
            throw new BusinessLogicException("Тур с таким названием в данном направлении и с такой датой уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Tour tour,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Tours.AnyAsync(x => x.IsnTour == tour.IsnTour, cancellationToken))
            throw new BusinessLogicException($"Тур с идентификатором \"{tour.IsnTour}\" не существует");

        if (tour.StartDate <= DateTime.Today.AddDays(7))
            throw new BusinessLogicException("Нельзя удалить тур, который начинается в течение недели");
    }
}