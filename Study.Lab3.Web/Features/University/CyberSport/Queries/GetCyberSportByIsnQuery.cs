using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.CyberSport.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.CyberSport.Queries;

/// <summary>
/// Получить количество участников по идентификатору
/// </summary>
public sealed class GetCyberSportByIsnQuery : IRequest<CyberSportDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCyberSport { get; init; }
}

public sealed class GetCyberSportByIsnQueryHandler : IRequestHandler<GetCyberSportByIsnQuery, CyberSportDto>
{
    private readonly DataContext _dataContext;

    public GetCyberSportByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CyberSportDto> Handle(GetCyberSportByIsnQuery request, CancellationToken cancellationToken)
    {
        var CyberSport = await _dataContext.CyberSport
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnCyberSport == request.IsnCyberSport, cancellationToken)
                ?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnCyberSport}\" не существует");

        return new CyberSportDto
        {
            IsnCyberSport = CyberSport.IsnCyberSport,
            IsnStudent = CyberSport.IsnStudent,
            IsnSubject = CyberSport.IsnSubject,
            PointsCount = CyberSport.PointsCount,
            CyberSportDate = CyberSport.CyberSportDate
        };
    }
}