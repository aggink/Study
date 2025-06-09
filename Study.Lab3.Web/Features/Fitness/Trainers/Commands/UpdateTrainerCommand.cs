using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Trainers.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Trainers.Commands;

/// <summary>
/// Редактирование тренера
/// </summary>
public sealed class UpdateTrainerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные тренера
    /// </summary>
    [Required]
    [FromBody]
    public UpdateTrainerDto Trainer { get; init; }
}

public sealed class UpdateTrainerCommandHandler : IRequestHandler<UpdateTrainerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessTrainerService _trainerService;

    public UpdateTrainerCommandHandler(
        DataContext dataContext,
        IFitnessTrainerService trainerService)
    {
        _dataContext = dataContext;
        _trainerService = trainerService;
    }

    public async Task<Guid> Handle(UpdateTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainer = await _dataContext.Trainers
                          .FirstOrDefaultAsync(x => x.IsnTrainer == request.Trainer.IsnTrainer, cancellationToken)
                      ?? throw new BusinessLogicException($"Тренер с идентификатором \"{request.Trainer.IsnTrainer}\" не существует");

        trainer.SurName = request.Trainer.SurName;
        trainer.Name = request.Trainer.Name;
        trainer.PatronymicName = request.Trainer.PatronymicName;
        trainer.PhoneNumber = request.Trainer.PhoneNumber;
        trainer.Email = request.Trainer.Email;
        trainer.Specialization = request.Trainer.Specialization;
        trainer.ExperienceYears = request.Trainer.ExperienceYears;
        trainer.Certifications = request.Trainer.Certifications;
        trainer.HourlyRate = request.Trainer.HourlyRate;
        trainer.IsActive = request.Trainer.IsActive;

        await _trainerService.CreateOrUpdateTrainerValidateAndThrowAsync(
            _dataContext, trainer, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return trainer.IsnTrainer;
    }
}