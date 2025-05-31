using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheSportclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.Queries;

/// <summary>
/// Получить количество участников с деталями
/// </summary>
public sealed class GetSportclubWithDetailsQuery : IRequest<SportclubWithDetailsDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    public Guid IsnSportclub { get; init; }
}

public sealed class GetSportclubWithDetailsQueryHandler : IRequestHandler<GetSportclubWithDetailsQuery, SportclubWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetSportclubWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SportclubWithDetailsDto> Handle(GetSportclubWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Sportclub
            .AsNoTracking()
            .Where(x => x.IsnSportclub == request.IsnSportclub)
            .Select(Sportclub => new SportclubWithDetailsDto
            {
                IsnSportclub = Sportclub.IsnSportclub,
                IsnStudent = Sportclub.IsnStudent,
                StudentFullName = $"{Sportclub.Student.SurName} {Sportclub.Student.Name} {Sportclub.Student.PatronymicName}",
                IsnSubject = Sportclub.IsnSubject,
                SubjectName = Sportclub.Subject.Name,
                ParticipantsCount = Sportclub.ParticipantsCount,
                SportclubDate = Sportclub.SportclubDate,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}