using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;

namespace Study.Lab3.Web.Features.Library.Authors.Queries;

/// <summary>
/// Получить список авторов
/// </summary>
public sealed class GetListAuthorsQuery : IRequest<AuthorItemDto[]>
{

}

public sealed class GetListAuthorsQueryHandler : IRequestHandler<GetListAuthorsQuery, AuthorItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListAuthorsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AuthorItemDto[]> Handle(GetListAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _dataContext.Authors
            .AsNoTracking()
            .Select(x => new AuthorItemDto
            {
                IsnAuthor = x.IsnAuthor,
                SurName = x.SurName,
                Name = x.Name,
                PatronymicName = x.PatronymicName,
                Sex = x.Sex,
                IsnTeacher = x.IsnTeacher
            })
            .OrderBy(x => x.SurName)
            .ToArrayAsync(cancellationToken);

        return authors;
    }
}