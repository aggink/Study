using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheSportclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.Queries;

/// <summary>
/// Получить количество участников по идентификатору
/// </summary>
public sealed class GetSportclubByIsnQuery : IRequest<SportclubDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSportclub { get; init; }
}

public sealed class GetSportclubByIsnQueryHandler : IRequestHandler<GetSportclubByIsnQuery, SportclubDto>
{
    private readonly DataContext _dataContext;

    public GetSportclubByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SportclubDto> Handle(GetSportclubByIsnQuery request, CancellationToken cancellationToken)
    {
        var Sportclub = await _dataContext.Sportclub
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnSportclub == request.IsnSportclub, cancellationToken)
                ?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnSportclub}\" не существует");

        return new SportclubDto
        {
            IsnSportclub = Sportclub.IsnSportclub,
            IsnStudent = Sportclub.IsnStudent,
            IsnSubject = Sportclub.IsnSubject,
            ParticipantsCount = Sportclub.ParticipantsCount,
            SportclubDate = Sportclub.SportclubDate
        };
    }
}