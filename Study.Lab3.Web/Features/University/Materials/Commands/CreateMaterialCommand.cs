/*using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Materials.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Materials.Commands;

/// <summary>
/// Создание учебного материала
/// </summary>
public sealed class CreateMaterialCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные материала
    /// </summary>
    [Required]
    [FromBody]
    public CreateMaterialDto Material { get; init; }
}

public sealed class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMaterialService _materialService;

    public CreateMaterialCommandHandler(
        DataContext dataContext,
        IMaterialService materialService)
    {
        _dataContext = dataContext;
        _materialService = materialService;
    }

    public async Task<Guid> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = new Material
        {
            IsnMaterial = Guid.NewGuid(),
            IsnSubject = request.Material.IsnSubject,
            Title = request.Material.Title,
            Description = request.Material.Description,
            Type = request.Material.Type,
            Url = request.Material.Url,
            PublishDate = request.Material.PublishDate
        };

        await _materialService.CreateOrUpdateMaterialValidateAndThrowAsync(
            _dataContext, material, cancellationToken);

        await _dataContext.Materials.AddAsync(material, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return material.IsnMaterial;
    }
}*/