using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Developers.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Developers.Queries;

/// <summary>
/// Получение разработчика по идентификатору
/// </summary>
public sealed class GetDeveloperByIsnQuery : IRequest<DeveloperDto>
{
    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnDeveloper { get; init; }
}

public sealed class GetDeveloperByIsnQueryHandler : IRequestHandler<GetDeveloperByIsnQuery, DeveloperDto>
{
    private readonly DataContext _dataContext;

    public GetDeveloperByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<DeveloperDto> Handle(GetDeveloperByIsnQuery request, CancellationToken cancellationToken)
    {
        var developer = await _dataContext.Developers
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.IsnDeveloper == request.IsnDeveloper, cancellationToken)
                        ?? throw new BusinessLogicException(
                            $"Разработчик с идентификатором \"{request.IsnDeveloper}\" не существует");

        return new DeveloperDto
        {
            IsnDeveloper = developer.IsnDeveloper,
            CompanyName = developer.CompanyName,
            Country = developer.Country,
            FoundedDate = developer.FoundedDate,
            Website = developer.Website,
            ContactEmail = developer.ContactEmail,
            IsActive = developer.IsActive,
            Description = developer.Description
        };
    }
}
