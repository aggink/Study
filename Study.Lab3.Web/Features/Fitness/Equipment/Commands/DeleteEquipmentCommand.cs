using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Fitness.Equipment.Commands;

/// <summary>
/// Удаление оборудования
/// </summary>
public sealed class DeleteEquipmentCommand : IRequest
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnEquipment { get; init; }
}

public sealed class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessEquipmentService _equipmentService;

    public DeleteEquipmentCommandHandler(
        DataContext dataContext,
        IFitnessEquipmentService equipmentService)
    {
        _dataContext = dataContext;
        _equipmentService = equipmentService;
    }

    public async Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = await _dataContext.Equipments
                            .FirstOrDefaultAsync(x => x.IsnEquipment == request.IsnEquipment, cancellationToken)
                        ?? throw new BusinessLogicException($"Оборудование с идентификатором \"{request.IsnEquipment}\" не существует");

        await _equipmentService.CanDeleteAndThrowAsync(
            _dataContext, equipment, cancellationToken);

        _dataContext.Equipments.Remove(equipment);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}