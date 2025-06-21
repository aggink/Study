using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhva.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhva.Queries;

public sealed class GetManhvaByIsnQuery : IRequest<ManhvaDto>
{
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class GetManhvaByIsnQueryHandler : IRequestHandler<GetManhvaByIsnQuery, ManhvaDto>
{
    private readonly DataContext _dataContext;

    public GetManhvaByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ManhvaDto> Handle(GetManhvaByIsnQuery request, CancellationToken cancellationToken)
    {
        var manhva = await _dataContext.Manhva
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
                ?? throw new BusinessLogicException($"Манги с идентификатором \"{request.IsnBook}\" не существует");

        return new ManhvaDto
        {
            IsnBook = manhva.IsnBook,
            Title = manhva.Title,
            PublicationYear = manhva.PublicationYear,
        };
    }
}