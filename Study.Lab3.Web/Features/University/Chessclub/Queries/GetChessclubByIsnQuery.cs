using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Chessclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Chessclub.Queries;

/// <summary>
/// Получить количество участников по идентификатору
/// </summary>
public sealed class GetChessclubByIsnQuery : IRequest<ChessclubDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnChessclub { get; init; }
}

public sealed class GetChessclubByIsnQueryHandler : IRequestHandler<GetChessclubByIsnQuery, ChessclubDto>
{
    private readonly DataContext _dataContext;

    public GetChessclubByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ChessclubDto> Handle(GetChessclubByIsnQuery request, CancellationToken cancellationToken)
    {
        var Chessclub = await _dataContext.Chessclub
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnChessclub == request.IsnChessclub, cancellationToken)
                ?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnChessclub}\" не существует");

        return new ChessclubDto
        {
            IsnChessclub = Chessclub.IsnChessclub,
            IsnStudent = Chessclub.IsnStudent,
            IsnSubject = Chessclub.IsnSubject,
            ParticipantsPip = Chessclub.ParticipantsPip,
            ChessclubDate = Chessclub.ChessclubDate
        };
    }
}