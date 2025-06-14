using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;
using Study.Lab3.Web.Features.TravelAgency.Tours.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Tours.Commands;

/// <summary>
/// Создание тура
/// </summary>
public sealed class CreateTourCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные тура
    /// </summary>
    [Required]
    [FromBody]
    public CreateTourDto Tour { get; init; }
}

public sealed class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ITourService _tourService;

    public CreateTourCommandHandler(
        DataContext dataContext,
        ITourService tourService)
    {
        _dataContext = dataContext;
        _tourService = tourService;
    }

    public async Task<Guid> Handle(CreateTourCommand request, CancellationToken cancellationToken)
    {
        var tour = new Tour
        {
            IsnTour = Guid.NewGuid(),
            Name = request.Tour.Name,
            Description = request.Tour.Description,
            Country = request.Tour.Country,
            City = request.Tour.City,
            Price = request.Tour.Price,
            Duration = request.Tour.Duration,
            StartDate = request.Tour.StartDate,
            EndDate = request.Tour.StartDate.AddDays(request.Tour.Duration - 1),
            MaxParticipants = request.Tour.MaxParticipants,
            IsAvailable = request.Tour.IsAvailable
        };

        await _tourService.CreateOrUpdateTourValidateAndThrowAsync(
            _dataContext, tour, cancellationToken);

        await _dataContext.Tours.AddAsync(tour, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return tour.IsnTour;
    }
}