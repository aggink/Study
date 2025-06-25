using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhva.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhva.Commands;

public sealed class CreateManhvaCommand : IRequest<Guid>
{
    [FromBody]
    [Required]
    public CreateManhvaDto Manhva { get; init; }
}

public sealed class CreateManhvaCommandHandler : IRequestHandler<CreateManhvaCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IManhvaService _manhvaService;

    public CreateManhvaCommandHandler(
        DataContext dataContext, IManhvaService manhvaService)
    {
        _dataContext = dataContext;
        _manhvaService = manhvaService;
    }

    public async Task<Guid> Handle(CreateManhvaCommand request, CancellationToken cancellationToken)
    {
        var manhva = new Storage.Models.AsianComics.Manhva
        {
            IsnBook = Guid.NewGuid(),
            Title = request.Manhva.Title,
            PublicationYear = request.Manhva.PublicationYear,
        };

        await _manhvaService.CreateOrUpdateManhvaValidateAndThrowAsync(_dataContext, manhva, cancellationToken);

        await _dataContext.Manhva.AddAsync(manhva, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return manhva.IsnBook;
    }
}

