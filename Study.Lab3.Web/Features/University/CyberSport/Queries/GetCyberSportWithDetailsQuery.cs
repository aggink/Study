using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.CyberSport.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.CyberSport.Queries;

/// <summary>
/// Получить количество участников с деталями
/// </summary>
public sealed class GetCyberSportWithDetailsQuery : IRequest<CyberSportWithDetailsDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    public Guid IsnCyberSport { get; init; }
}

public sealed class GetCyberSportWithDetailsQueryHandler : IRequestHandler<GetCyberSportWithDetailsQuery, CyberSportWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetCyberSportWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CyberSportWithDetailsDto> Handle(GetCyberSportWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.CyberSport
            .AsNoTracking()
            .Where(x => x.IsnCyberSport == request.IsnCyberSport)
            .Select(CyberSport => new CyberSportWithDetailsDto
            {
                IsnCyberSport = CyberSport.IsnCyberSport,
                IsnStudent = CyberSport.IsnStudent,
                StudentFullName = $"{CyberSport.Student.SurName} {CyberSport.Student.Name} {CyberSport.Student.PatronymicName}",
                IsnSubject = CyberSport.IsnSubject,
                SubjectName = CyberSport.Subject.Name,
                PointsCount = CyberSport.PointsCount,
                CyberSportDate = CyberSport.CyberSportDate,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}