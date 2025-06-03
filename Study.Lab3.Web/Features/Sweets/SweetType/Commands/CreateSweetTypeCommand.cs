using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using System.ComponentModel.DataAnnotations;
using Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Commands;

/// <summary>
/// Создание таблицы SweetProduction
/// </summary>
public sealed class CreateSweetTypeCommand : IRequest<long>
{
    /// <summary>
    /// Данные записи
    /// </summary>
    [Required]
    [FromBody]
    public CreateSweetTypeDto SweetType { get; init; }
}

public sealed class CreateSweetTypeCommandHandler : IRequestHandler<CreateSweetTypeCommand, long>
{
    private readonly DataContext _dataContext;

    public CreateSweetTypeCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<long> Handle(CreateSweetTypeCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности 
        if (await _dataContext.SweetTypes.AnyAsync(c => c.ID == request.SweetType.ID, cancellationToken))
            throw new BusinessLogicException($"Запись с индентификатором \"{request.SweetType.ID}\" уже существует");

        var sweettype = new SweetType
        {
            ID = request.SweetType.ID,
            Name = request.SweetType.Name
        };

        await _dataContext.SweetTypes.AddAsync(sweettype, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
        return sweettype.ID;
    }
}