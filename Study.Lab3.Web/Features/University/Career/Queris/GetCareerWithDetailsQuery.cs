using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.University.TheCareer.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheCareer.Queries;
=======
using Study.Lab3.Web.Features.University.Career.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Career.Queris;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

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
        var career = await _dataContext.Career
    .AsNoTracking()
    .FirstOrDefaultAsync(x => x.IsnCareer == request.IsnCareer, cancellationToken);

        if (career == null) return null;

        return new CareerWithDetailsDto
        {
            IsnCareer = career.IsnCareer,
            IsnStudent = career.IsnStudent,
            StudentFullName = $"{career.Student.SurName} {career.Student.Name} {career.Student.PatronymicName}",
            IsnSubject = career.IsnSubject,
            SubjectName = career.Subject.Name,
            ParticipantsCount = career.ParticipantsCount,
            CareerDate = career.CareerDate,
        };
    }
}