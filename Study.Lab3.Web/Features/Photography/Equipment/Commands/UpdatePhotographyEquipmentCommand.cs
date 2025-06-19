using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Equipment.Commands;

/// <summary>
/// Обновление оборудования фотостудии
/// </summary>
public sealed class UpdatePhotographyEquipmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные оборудования
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePhotographyEquipmentDto Equipment { get; init; }
}

public sealed class UpdatePhotographyEquipmentCommandHandler : IRequestHandler<UpdatePhotographyEquipmentCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographyEquipmentService _equipmentService;

    public UpdatePhotographyEquipmentCommandHandler(
        DataContext dataContext,
        IPhotographyEquipmentService equipmentService)
    {
        _dataContext = dataContext;
        _equipmentService = equipmentService;
    }

    public async Task<Guid> Handle(UpdatePhotographyEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = await _dataContext.PhotographyEquipments
                            .FirstOrDefaultAsync(x => x.IsnPhotographyEquipment == request.Equipment.IsnPhotographyEquipment,
                                cancellationToken)
                        ?? throw new BusinessLogicException(
                            $"Оборудование с идентификатором \"{request.Equipment.IsnPhotographyEquipment}\" не существует");

        equipment.Name = request.Equipment.Name;
        equipment.Type = request.Equipment.Type;
        equipment.Brand = request.Equipment.Brand;
        equipment.Model = request.Equipment.Model;
        equipment.SerialNumber = request.Equipment.SerialNumber;
        equipment.PurchaseDate = request.Equipment.PurchaseDate;
        equipment.Price = request.Equipment.Price;
        equipment.Status = request.Equipment.Status;
        equipment.Description = request.Equipment.Description;

        await _equipmentService.CreateOrUpdateEquipmentValidateAndThrowAsync(
            _dataContext, equipment, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return equipment.IsnPhotographyEquipment;
    }
}