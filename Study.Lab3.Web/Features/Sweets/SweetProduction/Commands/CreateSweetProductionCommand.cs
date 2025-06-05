using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProductions.Commands;

/// <summary>
/// Создание таблицы SweetProduction
/// </summary>
public sealed class CreateSweetProductionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи
    /// </summary>
    [Required]
    [FromBody]
    public CreateSweetProductionDto SweetProduction { get; init; }
}

public sealed class CreateSweetProductionCommandHandler : IRequestHandler<CreateSweetProductionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateSweetProductionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateSweetProductionCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности 
        if (await _dataContext.SweetProductions.AnyAsync(c => c.SweetFactoryID == request.SweetProduction.FactoryID &&  
            c.SweetID == request.SweetProduction.SweetID , cancellationToken))
            throw new BusinessLogicException($"Запись с индентификатором \"{request.SweetProduction.FactoryID}\" уже существует");

        var sweetproduction = new SweetProduction
        {
            SweetFactoryID = request.SweetProduction.FactoryID,
            SweetID = request.SweetProduction.SweetID
        };

        await _dataContext.SweetProductions.AddAsync(sweetproduction, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
        return sweetproduction.ID;
    }
}