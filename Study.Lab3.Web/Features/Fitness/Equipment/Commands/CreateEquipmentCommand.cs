using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;
using Study.Lab3.Web.Features.Fitness.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Equipment.Commands;

/// <summary>
/// Создание оборудования
/// </summary>
public sealed class CreateEquipmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные оборудования
    /// </summary>
    [Required]
    [FromBody]
    public CreateEquipmentDto Equipment { get; init; }
}

public sealed class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessEquipmentService _equipmentService;

    public CreateEquipmentCommandHandler(
        DataContext dataContext,
        IFitnessEquipmentService equipmentService)
    {
        _dataContext = dataContext;
        _equipmentService = equipmentService;
    }

    public async Task<Guid> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = new FitnessEquipment
        {
            IsnEquipment = Guid.NewGuid(),
            Name = request.Equipment.Name,
            Manufacturer = request.Equipment.Manufacturer,
            Model = request.Equipment.Model,
            SerialNumber = request.Equipment.SerialNumber,
            Type = request.Equipment.Type,
            PurchaseDate = request.Equipment.PurchaseDate,
            PurchasePrice = request.Equipment.PurchasePrice,
            Status = request.Equipment.Status,
            LastMaintenanceDate = request.Equipment.LastMaintenanceDate,
            Description = request.Equipment.Description
        };

        await _equipmentService.CreateOrUpdateEquipmentValidateAndThrowAsync(
            _dataContext, equipment, cancellationToken);

        await _dataContext.FitnessEquipments.AddAsync(equipment, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return equipment.IsnEquipment;
    }
}