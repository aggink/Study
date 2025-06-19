using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Photography.Equipment.Commands;

/// <summary>
/// Удаление оборудования фотостудии
/// </summary>
public sealed class DeletePhotographyEquipmentCommand : IRequest
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPhotographyEquipment { get; init; }
}

public sealed class DeletePhotographyEquipmentCommandHandler : IRequestHandler<DeletePhotographyEquipmentCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographyEquipmentService _equipmentService;

    public DeletePhotographyEquipmentCommandHandler(
        DataContext dataContext,
        IPhotographyEquipmentService equipmentService)
    {
        _dataContext = dataContext;
        _equipmentService = equipmentService;
    }

    public async Task Handle(DeletePhotographyEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = await _dataContext.PhotographyEquipments
                            .FirstOrDefaultAsync(x => x.IsnPhotographyEquipment == request.IsnPhotographyEquipment,
                                cancellationToken)
                        ?? throw new BusinessLogicException($"Оборудование с идентификатором \"{request.IsnPhotographyEquipment}\" не существует");

        await _equipmentService.CanDeleteAndThrowAsync(_dataContext, equipment, cancellationToken);

        _dataContext.PhotographyEquipments.Remove(equipment);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}