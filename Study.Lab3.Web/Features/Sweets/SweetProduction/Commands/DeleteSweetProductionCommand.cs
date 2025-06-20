using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProduction.Commands;

/// <summary>
/// Удаление элемента из SweetProduction
/// </summary>
public sealed class DeleteSweetProductionCommand : IRequest
{
    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    [Required]
    [FromQuery]
    public SweetProductionDto SweetProduction { get; init; }
}

public sealed class DeleteSweetProductionCommandHandler : IRequestHandler<DeleteSweetProductionCommand>
{
    private readonly DataContext _dataContext;

    public DeleteSweetProductionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteSweetProductionCommand request, CancellationToken cancellationToken)
    {
        var sweetproduction = await _dataContext.SweetProductions.FirstOrDefaultAsync(c => c.IsnSweetFactory == request.SweetProduction.IsnFactory &&
     c.IsnSweet == request.SweetProduction.IsnSweet, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрика с идентификатором \"{request.SweetProduction.IsnFactory}\" не существует");

        // Удаление записи
        _dataContext.SweetProductions.Remove(sweetproduction);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}