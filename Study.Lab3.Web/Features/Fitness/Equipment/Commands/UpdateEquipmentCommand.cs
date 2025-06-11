using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Equipment.Commands;

/// <summary>
/// Редактирование оборудования
/// </summary>
public sealed class UpdateEquipmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные оборудования
    /// </summary>
    [Required]
    [FromBody]
    public UpdateEquipmentDto Equipment { get; init; }
}

public sealed class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessEquipmentService _equipmentService;

    public UpdateEquipmentCommandHandler(
        DataContext dataContext,
        IFitnessEquipmentService equipmentService)
    {
        _dataContext = dataContext;
        _equipmentService = equipmentService;
    }

    public async Task<Guid> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = await _dataContext.Equipments
                            .FirstOrDefaultAsync(x => x.IsnEquipment == request.Equipment.IsnEquipment, cancellationToken)
                        ?? throw new BusinessLogicException($"Оборудование с идентификатором \"{request.Equipment.IsnEquipment}\" не существует");

        equipment.Name = request.Equipment.Name;
        equipment.Manufacturer = request.Equipment.Manufacturer;
        equipment.Model = request.Equipment.Model;
        equipment.SerialNumber = request.Equipment.SerialNumber;
        equipment.Type = request.Equipment.Type;
        equipment.PurchaseDate = request.Equipment.PurchaseDate;
        equipment.PurchasePrice = request.Equipment.PurchasePrice;
        equipment.Status = request.Equipment.Status;
        equipment.LastMaintenanceDate = request.Equipment.LastMaintenanceDate;
        equipment.Description = request.Equipment.Description;

        await _equipmentService.CreateOrUpdateEquipmentValidateAndThrowAsync(
            _dataContext, equipment, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return equipment.IsnEquipment;
    }
}