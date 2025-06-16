using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Equipment.Queries;

/// <summary>
/// Получение списка оборудования
/// </summary>
public sealed class GetListEquipmentQuery : IRequest<EquipmentDto[]>
{
}

public sealed class GetListEquipmentQueryHandler : IRequestHandler<GetListEquipmentQuery, EquipmentDto[]>
{
    private readonly DataContext _dataContext;

    public GetListEquipmentQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<EquipmentDto[]> Handle(GetListEquipmentQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.FitnessEquipments
            .AsNoTracking()
            .Select(x => new EquipmentDto
            {
                IsnEquipment = x.IsnEquipment,
                Name = x.Name,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                SerialNumber = x.SerialNumber,
                Type = x.Type,
                PurchaseDate = x.PurchaseDate,
                PurchasePrice = x.PurchasePrice,
                Status = x.Status,
                LastMaintenanceDate = x.LastMaintenanceDate,
                Description = x.Description
            })
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Manufacturer)
            .ToArrayAsync(cancellationToken);
    }
}