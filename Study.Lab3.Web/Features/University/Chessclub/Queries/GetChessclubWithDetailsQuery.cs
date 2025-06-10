using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Chessclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Chessclub.Queries;

/// <summary>
/// Получить количество участников с деталями
/// </summary>
public sealed class GetChessclubWithDetailsQuery : IRequest<ChessclubWithDetailsDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    public Guid IsnChessclub { get; init; }
}

public sealed class GetChessclubWithDetailsQueryHandler : IRequestHandler<GetChessclubWithDetailsQuery, ChessclubWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetChessclubWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ChessclubWithDetailsDto> Handle(GetChessclubWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Chessclub
            .AsNoTracking()
            .Where(x => x.IsnChessclub == request.IsnChessclub)
            .Select(Chessclub => new ChessclubWithDetailsDto
            {
                IsnChessclub = Chessclub.IsnChessclub,
                IsnStudent = Chessclub.IsnStudent,
                StudentFullName = $"{Chessclub.Student.SurName} {Chessclub.Student.Name} {Chessclub.Student.PatronymicName}",
                IsnSubject = Chessclub.IsnSubject,
                SubjectName = Chessclub.Subject.Name,
                ParticipantsPip = Chessclub.ParticipantsPip,
                ChessclubDate = Chessclub.ChessclubDate,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}