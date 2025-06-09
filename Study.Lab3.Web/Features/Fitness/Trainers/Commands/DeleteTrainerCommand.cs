using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Fitness.Trainers.Commands;

/// <summary>
/// Удаление тренера
/// </summary>
public sealed class DeleteTrainerCommand : IRequest
{
    /// <summary>
    /// Идентификатор тренера
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTrainer { get; init; }
}

public sealed class DeleteTrainerCommandHandler : IRequestHandler<DeleteTrainerCommand>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessTrainerService _trainerService;

    public DeleteTrainerCommandHandler(
        DataContext dataContext,
        IFitnessTrainerService trainerService)
    {
        _dataContext = dataContext;
        _trainerService = trainerService;
    }

    public async Task Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainer = await _dataContext.Trainers
                          .FirstOrDefaultAsync(x => x.IsnTrainer == request.IsnTrainer, cancellationToken)
                      ?? throw new BusinessLogicException($"Тренер с идентификатором \"{request.IsnTrainer}\" не существует");

        await _trainerService.CanDeleteAndThrowAsync(
            _dataContext, trainer, cancellationToken);

        _dataContext.Trainers.Remove(trainer);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
