using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactories.Commands;
=======
using Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactory.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

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

<<<<<<< HEAD
        var sweetfactory = new SweetFactory
=======
        var sweetfactory = new Storage.Models.Sweets.SweetFactory
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        {
            IsnSweetFactory = Guid.NewGuid(),
            Name = request.SweetFactory.Name,
            Address = request.SweetFactory.Adress,
            Volume = request.SweetFactory.Volume,
<<<<<<< HEAD
            SweetProductions = new List<SweetProduction>(),
=======
            SweetProductions = new List<Storage.Models.Sweets.SweetProduction>(),
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        };

        await _dataContext.SweetFactories.AddAsync(sweetfactory, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
<<<<<<< HEAD
        
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        return sweetfactory.IsnSweetFactory;
    }
}