using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.University.TheSportclub.DtoModels;

namespace Study.Lab3.Web.Features.University.TheSportclub.Queries;
=======
using Study.Lab3.Web.Features.University.Sportclub.DtoModels;

namespace Study.Lab3.Web.Features.University.Sportclub.Queries;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// ѕолучение списка количеств участников
/// </summary>
public sealed class GetListSportclubQuery : IRequest<SportclubDto[]>
{
}

public sealed class GetListSportclubQueryHandler : IRequestHandler<GetListSportclubQuery, SportclubDto[]>
{
    private readonly DataContext _dataContext;

    public GetListSportclubQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SportclubDto[]> Handle(GetListSportclubQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Sportclub
            .AsNoTracking()
            .Select(x => new SportclubDto
            {
                IsnSportclub = x.IsnSportclub,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                ParticipantsCount = x.ParticipantsCount,
                SportclubDate = x.SportclubDate
            })
            .OrderByDescending(x => x.SportclubDate)
            .ToArrayAsync(cancellationToken);
    }
}