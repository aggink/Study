using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactory.Commands;


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

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}