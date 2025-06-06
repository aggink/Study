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
public sealed class UpdateSweetProductionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные сладости
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSweetProductionDto SweetProduction { get; init; }
}

public sealed class UpdateSweetProductionCommandHandler : IRequestHandler<UpdateSweetProductionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateSweetProductionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateSweetProductionCommand request, CancellationToken cancellationToken)
    {
        var sweetproduction = await _dataContext.SweetProductions
                           .FirstOrDefaultAsync(c => c.IsnSweetProduction == request.SweetProduction.IsnSweetProduction, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрики с идентификатором \"{request.SweetProduction.IsnSweetProduction}\" не существует");

        sweetproduction.IsnSweetFactory = request.SweetProduction.IsnFactory;
        sweetproduction.IsnSweet = request.SweetProduction.IsnSweet;
        sweetproduction.IsnSweetProduction = request.SweetProduction.IsnSweetProduction;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sweetproduction.IsnSweetProduction;
    }
}