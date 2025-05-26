using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.Queries;

/// <summary>
/// Получить данные автора
/// </summary>
public class GetAuthorByIsnQuery : IRequest<AuthorDto>
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAuthor { get; init; }
}

public sealed class GetAuthorByIsnQueryHandler : IRequestHandler<GetAuthorByIsnQuery, AuthorDto>
{
    private readonly DataContext _dataContext;

    public GetAuthorByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AuthorDto> Handle(GetAuthorByIsnQuery request, CancellationToken cancellationToken)
    {
        var author = await _dataContext.Authors.FirstOrDefaultAsync(x => x.IsnAuthor == request.IsnAuthor, cancellationToken)
            ?? throw new BusinessLogicException($"Автора с идентификатором \"{request.IsnAuthor}\" не существует");

        return new AuthorDto
        {
            IsnAuthor = author.IsnAuthor,
            SurName = author.SurName,
            Name = author.Name,
            PatronymicName = author.PatronymicName,
            Sex = author.Sex,
            IsnTeacher = author.IsnTeacher
        };
    }
}
