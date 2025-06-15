using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Equipment.Queries;

/// <summary>
/// Получение оборудования по идентификатору
/// </summary>
public sealed class GetPhotographyEquipmentByIsnQuery : IRequest<PhotographyEquipmentDto>
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPhotographyEquipment { get; init; }
}

public sealed class GetPhotographyEquipmentByIsnQueryHandler : IRequestHandler<GetPhotographyEquipmentByIsnQuery, PhotographyEquipmentDto>
{
    private readonly DataContext _dataContext;

    public GetPhotographyEquipmentByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PhotographyEquipmentDto> Handle(GetPhotographyEquipmentByIsnQuery request, CancellationToken cancellationToken)
    {
        var equipment = await _dataContext.PhotographyEquipments
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.IsnPhotographyEquipment == request.IsnPhotographyEquipment,
                                cancellationToken)
                        ?? throw new BusinessLogicException(
                            $"Оборудование с идентификатором \"{request.IsnPhotographyEquipment}\" не существует");

        return new PhotographyEquipmentDto
        {
            IsnPhotographyEquipment = equipment.IsnPhotographyEquipment,
            Name = equipment.Name,
            Type = equipment.Type,
            Brand = equipment.Brand,
            Model = equipment.Model,
            SerialNumber = equipment.SerialNumber,
            PurchaseDate = equipment.PurchaseDate,
            Price = equipment.Price,
            Status = equipment.Status,
            Description = equipment.Description
        };
    }
}