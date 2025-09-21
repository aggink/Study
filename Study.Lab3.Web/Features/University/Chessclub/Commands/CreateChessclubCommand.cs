using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Chessclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Chessclub.Commands;

/// <summary>
/// Создание профкома
/// </summary>
public sealed class CreateChessclubCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные профкома
    /// </summary>
    [Required]
    [FromBody]
    public CreateChessclubDto Chessclub { get; init; }
}

public sealed class CreateChessclubCommandHandler : IRequestHandler<CreateChessclubCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IChessclubService _sportclubService;

    public CreateChessclubCommandHandler(
        DataContext dataContext,
        IChessclubService sportclubService)
    {
        _dataContext = dataContext;
        _sportclubService = sportclubService;
    }

    public async Task<Guid> Handle(CreateChessclubCommand request, CancellationToken cancellationToken)
    {
        var sportclub = new Storage.Models.University.Chessclub
        {
            IsnChessclub = Guid.NewGuid(),
            IsnStudent = request.Chessclub.IsnStudent,
            IsnSubject = request.Chessclub.IsnSubject,
            ParticipantsPip = request.Chessclub.ParticipantsPip,
            ChessclubDate = request.Chessclub.ChessclubDate
        };

        await _sportclubService.CreateOrUpdateChessclubValidateAndThrowAsync(
            _dataContext, sportclub, cancellationToken);

        await _dataContext.Chessclub.AddAsync(sportclub, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sportclub.IsnChessclub;
    }
}