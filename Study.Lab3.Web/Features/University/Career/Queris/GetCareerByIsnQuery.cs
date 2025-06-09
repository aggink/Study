using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Career.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Career.Queris;

/// <summary>
/// Получить количество участников по идентификатору
/// </summary>
public sealed class GetCareerByIsnQuery : IRequest<CareerDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCareer { get; init; }
}

public sealed class GetCareerByIsnQueryHandler : IRequestHandler<GetCareerByIsnQuery, CareerDto>
{
    private readonly DataContext _dataContext;

    public GetCareerByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CareerDto> Handle(GetCareerByIsnQuery request, CancellationToken cancellationToken)
    {
        var Career = await _dataContext.Career
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnCareer == request.IsnCareer, cancellationToken)
                ?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnCareer}\" не существует");

        return new CareerDto
        {
            IsnCareer = Career.IsnCareer,
            IsnStudent = Career.IsnStudent,
            IsnSubject = Career.IsnSubject,
            ParticipantsCount = Career.ParticipantsCount,
            CareerDate = Career.CareerDate
        };
    }
}