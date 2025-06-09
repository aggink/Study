using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetType.Commands;

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

        var sweettype = new Storage.Models.Sweets.SweetType
        {
            IsnSweetType = Guid.NewGuid(),
            Name = request.SweetType.Name
        };

        await _dataContext.SweetTypes.AddAsync(sweettype, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sweettype.IsnSweetType;
    }
}