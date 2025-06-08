using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Trainers.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Trainers.Queries;

/// <summary>
/// Получение тренера по идентификатору
/// </summary>
public sealed class GetTrainerByIsnQuery : IRequest<TrainerDto>
{
    /// <summary>
    /// Идентификатор тренера
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTrainer { get; init; }
}

public sealed class GetTrainerByIsnQueryHandler : IRequestHandler<GetTrainerByIsnQuery, TrainerDto>
{
    private readonly DataContext _dataContext;

    public GetTrainerByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TrainerDto> Handle(GetTrainerByIsnQuery request, CancellationToken cancellationToken)
    {
        var trainer = await _dataContext.Trainers
                          .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.IsnTrainer == request.IsnTrainer, cancellationToken)
                      ?? throw new BusinessLogicException($"Тренер с идентификатором \"{request.IsnTrainer}\" не существует");

        return new TrainerDto
        {
            IsnTrainer = trainer.IsnTrainer,
            SurName = trainer.SurName,
            Name = trainer.Name,
            PatronymicName = trainer.PatronymicName,
            PhoneNumber = trainer.PhoneNumber,
            Email = trainer.Email,
            Specialization = trainer.Specialization,
            ExperienceYears = trainer.ExperienceYears,
            Certifications = trainer.Certifications,
            HourlyRate = trainer.HourlyRate,
            IsActive = trainer.IsActive
        };
    }
}