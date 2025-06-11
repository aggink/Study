using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactory.Commands;

/// <summary>
/// Создание клиента
/// </summary>
public sealed class CreateSweetFactoryCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи
    /// </summary>
    [Required]
    [FromBody]
    public CreateSweetFactoryDto SweetFactory { get; init; }
}

public sealed class CreateSweetFactoryCommandHandler : IRequestHandler<CreateSweetFactoryCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateSweetFactoryCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateSweetFactoryCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности 
        if (await _dataContext.SweetFactories.AnyAsync(c => c.Name == request.SweetFactory.Name, cancellationToken))
            throw new BusinessLogicException($"Запись с индентификатором \"{request.SweetFactory.Name}\" уже существует");

        var sweetfactory = new Storage.Models.Sweets.SweetFactory
        {
            IsnSweetFactory = Guid.NewGuid(),
            Name = request.SweetFactory.Name,
            Address = request.SweetFactory.Address,
            Volume = request.SweetFactory.Volume,
            SweetProductions = new List<Storage.Models.Sweets.SweetProduction>(),
        };

        await _dataContext.SweetFactories.AddAsync(sweetfactory, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sweetfactory.IsnSweetFactory;
    }
}