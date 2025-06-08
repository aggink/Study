using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.Sweets.Commands;
=======
namespace Study.Lab3.Web.Features.Sweets.Sweet.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Удаление сладости
/// </summary>
public sealed class DeleteSweetCommand : IRequest
{
    /// <summary>
    /// Идентификатор сладости
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSweet { get; init; }
}

public sealed class DeleteSweetCommandHandler : IRequestHandler<DeleteSweetCommand>
{
    private readonly DataContext _dataContext;

    public DeleteSweetCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteSweetCommand request, CancellationToken cancellationToken)
    {
        var sweet = await _dataContext.Sweets
                           .Include(c => c.SweetType)
                           .FirstOrDefaultAsync(c => c.IsnSweet == request.IsnSweet, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Сладость с идентификатором \"{request.IsnSweet}\" не существует");

        // Удаление записи
        _dataContext.Sweets.Remove(sweet);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}