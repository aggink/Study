using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhua.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhua.Queries;

public sealed class GetManhuaByIsnQuery : IRequest<ManhuaDto>
{
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class GetManhuaByIsnQueryHandler : IRequestHandler<GetManhuaByIsnQuery, ManhuaDto>
{
    private readonly DataContext _dataContext;

    public GetManhuaByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ManhuaDto> Handle(GetManhuaByIsnQuery request, CancellationToken cancellationToken)
    {
        var manhua = await _dataContext.Manhua
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
                ?? throw new BusinessLogicException($"Манги с идентификатором \"{request.IsnBook}\" не существует");

        return new ManhuaDto
        {
            IsnBook = manhua.IsnBook,
            Title = manhua.Title,
            PublicationYear = manhua.PublicationYear,
        };
    }
}