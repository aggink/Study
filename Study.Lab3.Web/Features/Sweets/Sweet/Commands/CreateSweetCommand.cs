using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweets.Commands;

/// <summary>
/// Создание клиента
/// </summary>
public sealed class CreateSweetCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи
    /// </summary>
    [Required]
    [FromBody]
    public CreateSweetDto Sweet { get; init; }
}

public sealed class CreateSweetCommandHandler : IRequestHandler<CreateSweetCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateSweetCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateSweetCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности 
        if (await _dataContext.Sweets.AnyAsync(c => c.Name == request.Sweet.Name, cancellationToken))
            throw new BusinessLogicException($"Запись с индентификатором \"{request.Sweet.Name}\" уже существует");

        var sweet = new Sweet
        {
            Name = request.Sweet.Name,
            SweetTypeID = request.Sweet.SweetTypeID,
            Ingredients = request.Sweet.Ingredients,
            SweetProductions = new List<SweetProduction>(),
        };

        await _dataContext.Sweets.AddAsync(sweet, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
        return sweet.ID;
    }
}