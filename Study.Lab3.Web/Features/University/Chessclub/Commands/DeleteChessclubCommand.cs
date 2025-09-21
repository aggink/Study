using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Chessclub.Commands;

/// <summary>
/// Удаление шахматного клуба
/// </summary>
public sealed class DeleteChessclubCommand : IRequest
{
    /// <summary>
    /// Идентификатор спортивного клуба
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnChessclub { get; init; }
}

public sealed class DeleteChessclubCommandHandler : IRequestHandler<DeleteChessclubCommand>
{
    private readonly DataContext _dataContext;
    private readonly IChessclubService _chessclubService;

    public DeleteChessclubCommandHandler(
        DataContext dataContext,
        IChessclubService chessclubService)
    {
        _dataContext = dataContext;
        _chessclubService = chessclubService;
    }

    public async Task Handle(DeleteChessclubCommand request, CancellationToken cancellationToken)
    {
        var chessclub = await _dataContext.Chessclub
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnChessclub == request.IsnChessclub, cancellationToken)
                ?? throw new BusinessLogicException($"Соревнований с идентификатором \"{request.IsnChessclub}\" не существует");

        await _chessclubService.CanDeleteAndThrowAsync(
            _dataContext, chessclub, cancellationToken);

        _dataContext.Chessclub.Remove(chessclub);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}