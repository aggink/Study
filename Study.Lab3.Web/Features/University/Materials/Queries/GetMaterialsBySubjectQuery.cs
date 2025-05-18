using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Materials.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Materials.Queries;

/// <summary>
/// Получение материалов по предмету
/// </summary>
public sealed class GetMaterialsBySubjectQuery : IRequest<MaterialDto[]>
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSubject { get; init; }
}

public sealed class GetMaterialsBySubjectQueryHandler : IRequestHandler<GetMaterialsBySubjectQuery, MaterialDto[]>
{
    private readonly DataContext _dataContext;

    public GetMaterialsBySubjectQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MaterialDto[]> Handle(GetMaterialsBySubjectQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Subjects.AnyAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken))
            throw new BusinessLogicException($"Предмет с идентификатором \"{request.IsnSubject}\" не существует");

        return await _dataContext.Materials
            .AsNoTracking()
            .Where(x => x.IsnSubject == request.IsnSubject)
            .Select(x => new MaterialDto
            {
                IsnMaterial = x.IsnMaterial,
                IsnSubject = x.IsnSubject,
                Title = x.Title,
                Description = x.Description,
                Type = x.Type,
                Url = x.Url,
                PublishDate = x.PublishDate
            })
            .OrderByDescending(x => x.PublishDate)
            .ToArrayAsync(cancellationToken);
    }
}