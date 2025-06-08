using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweets.Commands;
=======
using Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweet.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

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

<<<<<<< HEAD
        var sweet = new Sweet
=======
        var sweet = new Storage.Models.Sweets.Sweet
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        {
            IsnSweet = Guid.NewGuid(),
            Name = request.Sweet.Name,
            IsnSweetType = request.Sweet.IsnSweetType,
            Ingredients = request.Sweet.Ingredients,
<<<<<<< HEAD
            SweetProductions = new List<SweetProduction>(),
=======
            SweetProductions = new List<Storage.Models.Sweets.SweetProduction>(),
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        };

        await _dataContext.Sweets.AddAsync(sweet, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
<<<<<<< HEAD
        
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        return sweet.IsnSweet;
    }
}