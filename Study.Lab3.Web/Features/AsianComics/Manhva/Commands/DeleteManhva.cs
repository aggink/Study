using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhva.Commands;

public sealed class DeleteManhvaCommand : IRequest
{
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class DeleteManhvaCommandHandler : IRequestHandler<DeleteManhvaCommand>
{
    private readonly DataContext _dataContext;
    private readonly IManhvaService _manhvaService;

    public DeleteManhvaCommandHandler(DataContext dataContext, IManhvaService manhvaService)
    {
        _dataContext = dataContext;
        _manhvaService = manhvaService;
    }

    public async Task Handle(DeleteManhvaCommand request, CancellationToken cancellationToken)
    {
        var manhva = await _dataContext.Manhva.FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($"Манги с идентификатором \"{request.IsnBook}\" не существует");

        _dataContext.Manhva.Remove(manhva);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
