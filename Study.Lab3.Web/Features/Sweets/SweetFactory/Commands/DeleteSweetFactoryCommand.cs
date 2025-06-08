using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetFactories.Commands;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetFactory.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117


/// <summary>
/// Удаление сладости
/// </summary>
public sealed class DeleteSweetFactoryCommand : IRequest
{
    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSweetFactory { get; init; }
}

public sealed class DeleteSweetFactoryCommandHandler : IRequestHandler<DeleteSweetFactoryCommand>
{
    private readonly DataContext _dataContext;

    public DeleteSweetFactoryCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteSweetFactoryCommand request, CancellationToken cancellationToken)
    {
        var sweetfactory = await _dataContext.SweetFactories.FirstOrDefaultAsync(c => c.IsnSweetFactory == request.IsnSweetFactory, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрика с идентификатором \"{request.IsnSweetFactory}\" не существует");

        // Удаление записи
        _dataContext.SweetFactories.Remove(sweetfactory);
<<<<<<< HEAD
        
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}