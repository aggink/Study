using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Materials.DtoModels;

namespace Study.Lab3.Web.Features.University.Materials.Commands;

/// <summary>
/// Обновление учебного материала
/// </summary>
public sealed class UpdateMaterialCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные материала
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMaterialDto Material { get; init; }
}

public sealed class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, Guid>
{
    private readonly DataContext      _dataContext;
    private readonly IMaterialService _materialService;

    public UpdateMaterialCommandHandler(
        DataContext dataContext,
        IMaterialService materialService)
    {
        _dataContext = dataContext;
        _materialService = materialService;
    }

    public async Task<Guid> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _dataContext.Materials
                                         .FirstOrDefaultAsync(x => x.IsnMaterial == request.Material.IsnMaterial,
                                             cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Материал с идентификатором \"{request.Material.IsnMaterial}\" не существует");

        material.Title = request.Material.Title;
        material.Description = request.Material.Description;
        material.Type = request.Material.Type;
        material.Url = request.Material.Url;

        await _materialService.CreateOrUpdateMaterialValidateAndThrowAsync(
            _dataContext, material, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return material.IsnMaterial;
    }
}