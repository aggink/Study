using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Genres.DtoModels;

namespace Study.Lab3.Web.Features.Cinema.Genres.Queries;

/// <summary>
/// Получение списка жанров
/// </summary>
public sealed class GetListGenresQuery : IRequest<GenreDto[]>
{
}

public sealed class GetListGenresQueryHandler : IRequestHandler<GetListGenresQuery, GenreDto[]>
{
    private readonly DataContext _dataContext;

    public GetListGenresQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GenreDto[]> Handle(GetListGenresQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Genres
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => new GenreDto
            {
                IsnGenre = x.IsnGenre,
                Name = x.Name
            })
            .ToArrayAsync(cancellationToken);
    }
}