using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;
using Study.Lab3.Web.Features.Fitness.Trainers.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Trainers.Commands;

/// <summary>
/// Создание тренера
/// </summary>
public sealed class CreateTrainerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные тренера
    /// </summary>
    [Required]
    [FromBody]
    public CreateTrainerDto Trainer { get; init; }
}

public sealed class CreateTrainerCommandHandler : IRequestHandler<CreateTrainerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessTrainerService _trainerService;

    public CreateTrainerCommandHandler(
        DataContext dataContext,
        IFitnessTrainerService trainerService)
    {
        _dataContext = dataContext;
        _trainerService = trainerService;
    }

    public async Task<Guid> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainer = new FitnessTrainer
        {
            IsnTrainer = Guid.NewGuid(),
            SurName = request.Trainer.SurName,
            Name = request.Trainer.Name,
            PatronymicName = request.Trainer.PatronymicName,
            PhoneNumber = request.Trainer.PhoneNumber,
            Email = request.Trainer.Email,
            Specialization = request.Trainer.Specialization,
            ExperienceYears = request.Trainer.ExperienceYears,
            Certifications = request.Trainer.Certifications,
            HourlyRate = request.Trainer.HourlyRate,
            IsActive = request.Trainer.IsActive
        };

        await _trainerService.CreateOrUpdateTrainerValidateAndThrowAsync(
            _dataContext, trainer, cancellationToken);

        await _dataContext.Trainers.AddAsync(trainer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return trainer.IsnTrainer;
    }
}