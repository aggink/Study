using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProductions.Commands;



/// <summary>
/// Обновление таблицы сладостей
/// </summary>
public sealed class UpdateSweetProductionCommand : IRequest<long>
{
    /// <summary>
    /// Данные сладости
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSweetProductionDto SweetProduction { get; init; }
}

public sealed class UpdateSweetFactoryCommandHandler : IRequestHandler<UpdateSweetProductionCommand, long>
{
    private readonly DataContext _dataContext;

    public UpdateSweetFactoryCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<long> Handle(UpdateSweetProductionCommand request, CancellationToken cancellationToken)
    {
        var sweetproduction = await _dataContext.SweetProductions
                           .FirstOrDefaultAsync(c => c.SweetFactoryID == request.SweetProduction.FactoryID, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрики с идентификатором \"{request.SweetProduction.FactoryID}\" не существует");

        sweetproduction.SweetFactoryID = request.SweetProduction.FactoryID;
        sweetproduction.SweetID = request.SweetProduction.SweetID;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sweetproduction.SweetFactoryID;
    }
}