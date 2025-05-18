using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Materials.DtoModels;

namespace Study.Lab3.Web.Features.University.Materials.Queries;

/// <summary>
/// Получить материал по идентификатору
/// </summary>
public sealed class GetMaterialByIsnQuery : IRequest<MaterialDto>
{
    /// <summary>
    /// Идентификатор материала
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMaterial { get; init; }
}

public sealed class GetMaterialByIsnQueryHandler : IRequestHandler<GetMaterialByIsnQuery, MaterialDto>
{
    private readonly DataContext _dataContext;

    public GetMaterialByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MaterialDto> Handle(GetMaterialByIsnQuery request, CancellationToken cancellationToken)
    {
        var material = await _dataContext.Materials
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(x => x.IsnMaterial == request.IsnMaterial,
                                             cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Материал с идентификатором \"{request.IsnMaterial}\" не существует");

        return new MaterialDto
        {
            IsnMaterial = material.IsnMaterial,
            IsnSubject = material.IsnSubject,
            Title = material.Title,
            Description = material.Description,
            Type = material.Type,
            Url = material.Url,
            PublishDate = material.PublishDate
        };
    }
}