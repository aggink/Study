using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.TravelAgency.Tours.Commands;

/// <summary>
/// Удаление тура
/// </summary>
public sealed class DeleteTourCommand : IRequest
{
    /// <summary>
    /// Идентификатор тура
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTour { get; init; }
}

public sealed class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand>
{
    private readonly DataContext _dataContext;
    private readonly ITourService _tourService;

    public DeleteTourCommandHandler(
        DataContext dataContext,
        ITourService tourService)
    {
        _dataContext = dataContext;
        _tourService = tourService;
    }

    public async Task Handle(DeleteTourCommand request, CancellationToken cancellationToken)
    {
        var tour = await _dataContext.Tours
                       .FirstOrDefaultAsync(x => x.IsnTour == request.IsnTour, cancellationToken)
                   ?? throw new BusinessLogicException($"Тур с идентификатором \"{request.IsnTour}\" не существует");

        await _tourService.CanDeleteAndThrowAsync(_dataContext, tour, cancellationToken);

        _dataContext.Tours.Remove(tour);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}