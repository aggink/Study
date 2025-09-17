using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhua.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhua.Commands;

public sealed class CreateManhuaCommand : IRequest<Guid>
{
    [FromBody]
    [Required]
    public CreateManhuaDto Manhua { get; init; }
}

public sealed class CreateManhuaCommandHandler : IRequestHandler<CreateManhuaCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IManhuaService _manhuaService;

    public CreateManhuaCommandHandler(
        DataContext dataContext, IManhuaService manhuaService)
    {
        _dataContext = dataContext;
        _manhuaService = manhuaService;
    }

    public async Task<Guid> Handle(CreateManhuaCommand request, CancellationToken cancellationToken)
    {
        var manhua = new Storage.Models.AsianComics.Manhua
        {
            IsnBook = Guid.NewGuid(),
            Title = request.Manhua.Title,
            PublicationYear = request.Manhua.PublicationYear,
        };

        await _manhuaService.CreateOrUpdateManhuaValidateAndThrowAsync(_dataContext, manhua, cancellationToken);

        await _dataContext.Manhua.AddAsync(manhua, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return manhua.IsnBook;
    }
}

