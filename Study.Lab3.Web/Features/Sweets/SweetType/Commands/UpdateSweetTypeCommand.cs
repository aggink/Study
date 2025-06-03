using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Commands;




/// <summary>
/// Обновление таблицы сладостей
/// </summary>
public sealed class UpdateSweetTypeCommand : IRequest<long>
{
    /// <summary>
    /// Данные сладости
    /// </summary>
    [Required]
    [FromBody]
    public Int64 ID { get; init; }
}

public sealed class UpdateSweetFactoryCommandHandler : IRequestHandler<UpdateSweetTypeCommand, long>
{
    private readonly DataContext _dataContext;

    public UpdateSweetFactoryCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<long> Handle(UpdateSweetTypeCommand request, CancellationToken cancellationToken)
    {
        var sweettype = await _dataContext.SweetTypes
                           .FirstOrDefaultAsync(c => c.ID == request.ID, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрики с идентификатором \"{request.ID}\" не существует");

        sweettype.ID = request.ID;
        sweetproduction.SweetID = request.SweetProduction.SweetID;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sweetproduction.SweetFactoryID;
    }
}