using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.University.TheCareer.DtoModels;

namespace Study.Lab3.Web.Features.University.TheCareer.Queries;
=======
using Study.Lab3.Web.Features.University.Career.DtoModels;

namespace Study.Lab3.Web.Features.University.Career.Queris;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

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