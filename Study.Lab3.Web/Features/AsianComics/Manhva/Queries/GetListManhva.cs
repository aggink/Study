using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhva.DtoModels;

namespace Study.Lab3.Web.Features.AsianComics.Manhva.Queries;

public sealed class GetListManhvaQuery : IRequest<ManhvaDto[]>
{

}

public sealed class GetListManhvasQueryHandler : IRequestHandler<GetListManhvaQuery, ManhvaDto[]>
{
    private readonly DataContext _dataContext;

    public GetListManhvasQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ManhvaDto[]> Handle(GetListManhvaQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Manhva
            .AsNoTracking()
            .Select(x => new ManhvaDto
            {
                IsnBook = x.IsnBook,
                Title = x.Title,
                PublicationYear = x.PublicationYear
            })
            .OrderBy(x => x.Title)
            .ToArrayAsync(cancellationToken);
    }
}