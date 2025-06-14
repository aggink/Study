using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigs.Commands;

public sealed class DeleteMiniPigCommand : IRequest
{
    /// <summary>
    /// Идентификатор кота
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMiniPig { get; init; }
}

/// <summary>
/// Обработчик удаления кота
/// </summary>
public sealed class DeleteMiniPigCommandHandler : IRequestHandler<DeleteMiniPigCommand>
{
    private readonly DataContext _dataContext;

    public DeleteMiniPigCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteMiniPigCommand request, CancellationToken cancellationToken)
    {
        var minipig = await _dataContext.MiniPigs
                      .FirstOrDefaultAsync(c => c.IsnMiniPig == request.IsnMiniPig, cancellationToken)
                  ?? throw new BusinessLogicException($"Мини пиг с идентификатором \"{request.IsnMiniPig}\" не существует");

        _dataContext.MiniPigs.Remove(minipig);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}