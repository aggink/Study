using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;
using Study.Lab3.Web.Features.Photography.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Equipment.Commands;

/// <summary>
/// Создание оборудования фотостудии
/// </summary>
public sealed class CreatePhotographyEquipmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные оборудования
    /// </summary>
    [Required]
    [FromBody]
    public CreatePhotographyEquipmentDto Equipment { get; init; }
}

public sealed class CreatePhotographyEquipmentCommandHandler : IRequestHandler<CreatePhotographyEquipmentCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographyEquipmentService _equipmentService;

    public CreatePhotographyEquipmentCommandHandler(
        DataContext dataContext,
        IPhotographyEquipmentService equipmentService)
    {
        _dataContext = dataContext;
        _equipmentService = equipmentService;
    }

    public async Task<Guid> Handle(CreatePhotographyEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = new PhotographyEquipment
        {
            IsnPhotographyEquipment = Guid.NewGuid(),
            Name = request.Equipment.Name,
            Type = request.Equipment.Type,
            Brand = request.Equipment.Brand,
            Model = request.Equipment.Model,
            SerialNumber = request.Equipment.SerialNumber,
            PurchaseDate = request.Equipment.PurchaseDate,
            Price = request.Equipment.Price,
            Status = request.Equipment.Status,
            Description = request.Equipment.Description
        };

        await _equipmentService.CreateOrUpdateEquipmentValidateAndThrowAsync(
            _dataContext, equipment, cancellationToken);

        await _dataContext.PhotographyEquipments.AddAsync(equipment, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return equipment.IsnPhotographyEquipment;
    }
}