using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Movies.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Queries;

/// <summary>
/// Получение фильма по идентификатору
/// </summary>
public sealed class GetMovieByIdQuery : IRequest<MovieDto>
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMovie { get; init; }
}

public sealed class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
{
    private readonly DataContext _dataContext;

    public GetMovieByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _dataContext.Movies
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.IsnMovie == request.IsnMovie, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Фильм с идентификатором \"{request.IsnMovie}\" не существует");

        return new MovieDto
        {
            IsnMovie = movie.IsnMovie,
            Title = movie.Title,
            Description = movie.Description,
            Duration = movie.Duration,
            Rating = movie.Rating,
            Year = movie.Year,
            Country = movie.Country,
            AgeRating = movie.AgeRating,
            IsActive = movie.IsActive,
            CreatedAt = movie.CreatedAt
        };
    }
}