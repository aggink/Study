using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhua.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhua.Commands;

public sealed class UpdateManhuaCommand : IRequest<Guid>
{
    [Required]
    [FromBody]
    public UpdateManhuaDto Manhua { get; init; }
}

public sealed class UpdateManhuaCommandHandler : IRequestHandler<UpdateManhuaCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IManhuaService _manhuaService;

    public UpdateManhuaCommandHandler(DataContext dataContext, IManhuaService manhuaService)
    {
        _dataContext = dataContext;
        _manhuaService = manhuaService;
    }

    public async Task<Guid> Handle(UpdateManhuaCommand request, CancellationToken cancellationToken)
    {
        var manhua = await _dataContext.Manhua.FirstOrDefaultAsync(x => x.IsnBook == request.Manhua.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.Manhua.IsnBook}\" не существует");

        manhua.Title = request.Manhua.Title;
        manhua.PublicationYear = request.Manhua.PublicationYear;

        await _manhuaService.CreateOrUpdateManhuaValidateAndThrowAsync(_dataContext, manhua, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return manhua.IsnBook;
    }
}