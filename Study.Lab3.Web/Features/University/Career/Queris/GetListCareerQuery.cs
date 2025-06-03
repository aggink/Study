using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheCareer.DtoModels;

namespace Study.Lab3.Web.Features.University.TheCareer.Queries;

/// <summary>
/// Њолучение списка количеств участников
/// </summary>
public sealed class GetListCareerQuery : IRequest<CareerDto[]>
{
}

public sealed class GetListCareerQueryHandler : IRequestHandler<GetListCareerQuery, CareerDto[]>
{
    private readonly DataContext _dataContext;

    public GetListCareerQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CareerDto[]> Handle(GetListCareerQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Career
            .AsNoTracking()
            .Select(x => new CareerDto
            {
                IsnCareer = x.IsnCareer,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                ParticipantsCount = x.ParticipantsCount,
                CareerDate = x.CareerDate
            })
            .OrderByDescending(x => x.CareerDate)
            .ToArrayAsync(cancellationToken);
    }
}