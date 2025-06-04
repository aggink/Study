using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProductions.Commands;



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
        var sweetproduction = await _dataContext.SweetProductions.FirstOrDefaultAsync(c => c.SweetFactoryID == request.SweetProduction.FactoryID &&
     c.SweetID == request.SweetProduction.SweetID, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрика с идентификатором \"{request.SweetProduction.FactoryID}\" не существует");

        // Удаление записи
        _dataContext.SweetProductions.Remove(sweetproduction);
        
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}