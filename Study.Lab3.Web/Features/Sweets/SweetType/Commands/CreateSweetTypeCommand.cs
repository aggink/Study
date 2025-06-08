using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using System.ComponentModel.DataAnnotations;
using Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Commands;
=======
using Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetType.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Создание таблицы SweetProduction
/// </summary>
public sealed class CreateSweetTypeCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи
    /// </summary>
    [Required]
    [FromBody]
    public CreateSweetTypeDto SweetType { get; init; }
}

public sealed class CreateSweetTypeCommandHandler : IRequestHandler<CreateSweetTypeCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateSweetTypeCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateSweetTypeCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности 
        if (await _dataContext.SweetTypes.AnyAsync(c => c.Name == request.SweetType.Name, cancellationToken))
            throw new BusinessLogicException($"Запись с индентификатором \"{request.SweetType.Name}\" уже существует");

<<<<<<< HEAD
        var sweettype = new SweetType
=======
        var sweettype = new Storage.Models.Sweets.SweetType
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        {
            IsnSweetType = Guid.NewGuid(),
            Name = request.SweetType.Name
        };

        await _dataContext.SweetTypes.AddAsync(sweettype, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
<<<<<<< HEAD
        
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        return sweettype.IsnSweetType;
    }
}