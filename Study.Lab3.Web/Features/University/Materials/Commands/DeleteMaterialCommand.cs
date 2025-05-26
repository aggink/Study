/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Materials.Commands;

/// <summary>
/// Удаление учебного материала
/// </summary>
public sealed class DeleteMaterialCommand : IRequest
{
    /// <summary>
    /// Идентификатор материала
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMaterial { get; init; }
}

public sealed class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMaterialService _materialService;

    public DeleteMaterialCommandHandler(
        DataContext dataContext,
        IMaterialService materialService)
    {
        _dataContext = dataContext;
        _materialService = materialService;
    }

    public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _dataContext.Materials
                           .FirstOrDefaultAsync(x => x.IsnMaterial == request.IsnMaterial,
                               cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Материал с идентификатором \"{request.IsnMaterial}\" не существует");

        await _materialService.CanDeleteAndThrowAsync(
            _dataContext, material, cancellationToken);

        _dataContext.Materials.Remove(material);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}*/