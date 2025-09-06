using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhua.DtoModels;

namespace Study.Lab3.Web.Features.AsianComics.Manhua.Queries;

public sealed class GetListManhuaQuery : IRequest<ManhuaDto[]>
{

}

public sealed class GetListManhuasQueryHandler : IRequestHandler<GetListManhuaQuery, ManhuaDto[]>
{
    private readonly DataContext _dataContext;

    public GetListManhuasQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ManhuaDto[]> Handle(GetListManhuaQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Manhua
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Select(x => new ManhuaDto
            {
                IsnBook = x.IsnBook,
                Title = x.Title,
                PublicationYear = x.PublicationYear
            })
            .ToArrayAsync(cancellationToken);
    }
}