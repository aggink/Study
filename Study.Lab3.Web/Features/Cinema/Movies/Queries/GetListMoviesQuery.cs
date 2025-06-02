using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Movies.DtoModels;

namespace Study.Lab3.Web.Features.Cinema.Movies.Queries;

/// <summary>
/// Получение списка фильмов
/// </summary>
public sealed class GetListMoviesQuery : IRequest<MovieDto[]>
{
}

public sealed class GetListMoviesQueryHandler : IRequestHandler<GetListMoviesQuery, MovieDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMoviesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MovieDto[]> Handle(GetListMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Movies
            .AsNoTracking()
            .OrderByDescending(x => x.Year)
            .ThenBy(x => x.Title)
            .Select(x => new MovieDto
            {
                IsnMovie = x.IsnMovie,
                Title = x.Title,
                Description = x.Description,
                Duration = x.Duration,
                Rating = x.Rating,
                Year = x.Year,
                Country = x.Country,
                AgeRating = x.AgeRating,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt
            })
            .ToArrayAsync(cancellationToken);
    }
}