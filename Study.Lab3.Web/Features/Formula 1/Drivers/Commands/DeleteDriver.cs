using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Formula1.Drivers.Commands;

/// <summary>
/// Удаление гонщика
/// </summary>
public sealed class DeleteDriverCommand : IRequest
{
    /// <summary>
    /// Идентификатор гонщика
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnDriver { get; init; }
}

public sealed class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand>
{
    private readonly DataContext _dataContext;

    public DeleteDriverCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _dataContext.Drivers.FirstOrDefaultAsync(x => x.IsnDriver == request.IsnDriver, cancellationToken)
            ?? throw new BusinessLogicException($"Гонщика с идентификатором \"{request.IsnDriver}\" не существует");

        _dataContext.Drivers.Remove(driver);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}