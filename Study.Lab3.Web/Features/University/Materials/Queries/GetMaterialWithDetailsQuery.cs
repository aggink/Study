using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Materials.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Materials.Queries;

/// <summary>
/// Получить материал с детальной информацией
/// </summary>
public sealed class GetMaterialWithDetailsQuery : IRequest<MaterialWithDetailsDto>
{
    /// <summary>
    /// Идентификатор материала
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMaterial { get; init; }
}

public sealed class GetMaterialWithDetailsQueryHandler : IRequestHandler<GetMaterialWithDetailsQuery, MaterialWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetMaterialWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MaterialWithDetailsDto> Handle(GetMaterialWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.Materials
                   .AsNoTracking()
                   .Where(x => x.IsnMaterial == request.IsnMaterial)
                   .Select(x => new MaterialWithDetailsDto
                   {
                       IsnMaterial = x.IsnMaterial,
                       IsnSubject = x.IsnSubject,
                       SubjectName = x.Subject.Name,
                       Title = x.Title,
                       Description = x.Description,
                       Type = x.Type,
                       Url = x.Url,
                       PublishDate = x.PublishDate
                   })
                   .FirstOrDefaultAsync(cancellationToken)
               ?? throw new BusinessLogicException(
                   $"Материал с идентификатором \"{request.IsnMaterial}\" не существует");
    }
}