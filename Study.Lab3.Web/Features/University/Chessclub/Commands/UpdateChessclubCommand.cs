using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Chessclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Chessclub.Commands;

/// <summary>
/// Редактирование шахматного клуба
/// </summary>
public sealed class UpdateChessclubCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные шахматного клуба
    /// </summary>
    [Required]
    [FromBody]
    public UpdateChessclubDto Chessclub { get; init; }
}

public sealed class UpdateChessclubCommandHandler : IRequestHandler<UpdateChessclubCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IChessclubService _chessclubService;

    public UpdateChessclubCommandHandler(
        DataContext dataContext,
        IChessclubService chessclubService)
    {
        _dataContext = dataContext;
        _chessclubService = chessclubService;
    }

    public async Task<Guid> Handle(UpdateChessclubCommand request, CancellationToken cancellationToken)
    {
        var chessclub = await _dataContext.Chessclub
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnChessclub == request.Chessclub.IsnChessclub, cancellationToken)
                ?? throw new BusinessLogicException($"Соревнований с идентификатором \"{request.Chessclub.IsnChessclub}\" не существует");

        chessclub.ParticipantsPip = request.Chessclub.ParticipantsCount;
        chessclub.ChessclubDate = request.Chessclub.ChessclubDate;

        await _chessclubService.CreateOrUpdateChessclubValidateAndThrowAsync(
            _dataContext, chessclub, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return chessclub.IsnChessclub;
    }
}