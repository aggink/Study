using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Tours.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Tours.Commands;

/// <summary>
/// Обновление тура
/// </summary>
public sealed class UpdateTourCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные тура
    /// </summary>
    [Required]
    [FromBody]
    public UpdateTourDto Tour { get; init; }
}

public sealed class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ITourService _tourService;

    public UpdateTourCommandHandler(
        DataContext dataContext,
        ITourService tourService)
    {
        _dataContext = dataContext;
        _tourService = tourService;
    }

    public async Task<Guid> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
    {
        var tour = await _dataContext.Tours
                       .FirstOrDefaultAsync(x => x.IsnTour == request.Tour.IsnTour, cancellationToken)
                   ?? throw new BusinessLogicException($"Тур с идентификатором \"{request.Tour.IsnTour}\" не существует");

        tour.Name = request.Tour.Name;
        tour.Description = request.Tour.Description;
        tour.Country = request.Tour.Country;
        tour.City = request.Tour.City;
        tour.Price = request.Tour.Price;
        tour.Duration = request.Tour.Duration;
        tour.StartDate = request.Tour.StartDate;
        tour.EndDate = request.Tour.StartDate.AddDays(request.Tour.Duration - 1);
        tour.MaxParticipants = request.Tour.MaxParticipants;
        tour.IsAvailable = request.Tour.IsAvailable;

        await _tourService.CreateOrUpdateTourValidateAndThrowAsync(
            _dataContext, tour, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return tour.IsnTour;
    }
}