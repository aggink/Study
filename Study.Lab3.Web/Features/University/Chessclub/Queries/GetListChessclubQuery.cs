using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Chessclub.DtoModels;

namespace Study.Lab3.Web.Features.University.Chesscllub.Queries;

/// <summary>
/// ѕолучение списка количеств участников
/// </summary>
public sealed class GetListChesscllubQuery : IRequest<ChessclubDto[]>
{
}

public sealed class GetListChesscllubQueryHandler : IRequestHandler<GetListChesscllubQuery, ChessclubDto[]>
{
    private readonly DataContext _dataContext;

    public GetListChesscllubQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ChessclubDto[]> Handle(GetListChesscllubQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Chessclub
            .AsNoTracking()
            .Select(x => new ChessclubDto
            {
                IsnChessclub = x.IsnChessclub,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                ParticipantsPip = x.ParticipantsPip,
                ChessclubDate = x.ChessclubDate
            })
            .OrderByDescending(x => x.ChessclubDate)
            .ToArrayAsync(cancellationToken);
    }
}