using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Trainers.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Trainers.Queries;

/// <summary>
/// Получение списка тренеров
/// </summary>
public sealed class GetListTrainersQuery : IRequest<TrainerDto[]>
{
}

public sealed class GetListTrainersQueryHandler : IRequestHandler<GetListTrainersQuery, TrainerDto[]>
{
    private readonly DataContext _dataContext;

    public GetListTrainersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TrainerDto[]> Handle(GetListTrainersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Trainers
            .AsNoTracking()
            .Select(x => new TrainerDto
            {
                IsnTrainer = x.IsnTrainer,
                SurName = x.SurName,
                Name = x.Name,
                PatronymicName = x.PatronymicName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Specialization = x.Specialization,
                ExperienceYears = x.ExperienceYears,
                Certifications = x.Certifications,
                HourlyRate = x.HourlyRate,
                IsActive = x.IsActive
            })
            .OrderBy(x => x.SurName)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}