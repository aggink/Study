using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheCareer.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheCareer.Queries;

/// <summary>
/// Получить количество участников с деталями
/// </summary>
public sealed class GetCareerWithDetailsQuery : IRequest<CareerWithDetailsDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    public Guid IsnCareer { get; init; }
}

public sealed class GetCareerWithDetailsQueryHandler : IRequestHandler<GetCareerWithDetailsQuery, CareerWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetCareerWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CareerWithDetailsDto> Handle(GetCareerWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Career
            .AsNoTracking()
            .Where(x => x.IsnCareer == request.IsnCareer)
            .Select(Career => new CareerWithDetailsDto
            {
                IsnCareer = Career.IsnCareer,
                IsnStudent = Career.IsnStudent,
                StudentFullName = $"{Career.Student.SurName} {Career.Student.Name} {Career.Student.PatronymicName}",
                IsnSubject = Career.IsnSubject,
                SubjectName = Career.Subject.Name,
                ParticipantsCount = Career.ParticipantsCount,
                CareerDate = Career.CareerDate,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}