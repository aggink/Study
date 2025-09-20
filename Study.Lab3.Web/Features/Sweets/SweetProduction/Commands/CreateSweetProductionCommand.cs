using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProduction.Commands;

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
        if (await _dataContext.SweetProductions.AnyAsync(c => c.IsnSweetFactory == request.SweetProduction.IsnFactory &&
            c.IsnSweet == request.SweetProduction.IsnSweet, cancellationToken))
            throw new BusinessLogicException($"Запись с индентификатором \"{request.SweetProduction.IsnFactory}\" уже существует");

        var sweetProduction = new Storage.Models.Sweets.SweetProduction
        {
            IsnSweetProduction = Guid.NewGuid(),
            IsnSweetFactory = request.SweetProduction.IsnFactory,
            IsnSweet = request.SweetProduction.IsnSweet
        };

        await _dataContext.SweetProductions.AddAsync(sweetProduction, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sweetProduction.IsnSweetProduction;
    }
}