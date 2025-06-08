using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Equipment.Queries;

/// <summary>
/// Получение оборудования по идентификатору
/// </summary>
public sealed class GetEquipmentByIsnQuery : IRequest<EquipmentDto>
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnEquipment { get; init; }
}

public sealed class GetEquipmentByIsnQueryHandler : IRequestHandler<GetEquipmentByIsnQuery, EquipmentDto>
{
    private readonly DataContext _dataContext;

    public GetEquipmentByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<EquipmentDto> Handle(GetEquipmentByIsnQuery request, CancellationToken cancellationToken)
    {
        var equipment = await _dataContext.Equipments
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.IsnEquipment == request.IsnEquipment, cancellationToken)
                        ?? throw new BusinessLogicException($"Оборудование с идентификатором \"{request.IsnEquipment}\" не существует");

        return new EquipmentDto
        {
            IsnEquipment = equipment.IsnEquipment,
            Name = equipment.Name,
            Manufacturer = equipment.Manufacturer,
            Model = equipment.Model,
            SerialNumber = equipment.SerialNumber,
            Type = equipment.Type,
            PurchaseDate = equipment.PurchaseDate,
            PurchasePrice = equipment.PurchasePrice,
            Status = equipment.Status,
            LastMaintenanceDate = equipment.LastMaintenanceDate,
            Description = equipment.Description
        };
    }
}