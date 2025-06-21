using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manhva.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhva.Commands;

public sealed class UpdateManhvaCommand : IRequest<Guid>
{
    [Required]
    [FromBody]
    public UpdateManhvaDto Manhva { get; init; }
}

public sealed class UpdateManhvaCommandHandler : IRequestHandler<UpdateManhvaCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IManhvaService _manhvaService;

    public UpdateManhvaCommandHandler(DataContext dataContext, IManhvaService manhvaService)
    {
        _dataContext = dataContext;
        _manhvaService = manhvaService;
    }

    public async Task<Guid> Handle(UpdateManhvaCommand request, CancellationToken cancellationToken)
    {
        var manhva = await _dataContext.Manhva.FirstOrDefaultAsync(x => x.IsnBook == request.Manhva.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($" ниги с идентификатором \"{request.Manhva.IsnBook}\" не существует");

        manhva.Title = request.Manhva.Title;
        manhva.PublicationYear = request.Manhva.PublicationYear;

        await _manhvaService.CreateOrUpdateManhvaValidateAndThrowAsync(_dataContext, manhva, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return manhva.IsnBook;
    }
}