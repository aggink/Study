using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhua.Commands;

public sealed class DeleteManhuaCommand : IRequest
{
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class DeleteManhuaCommandHandler : IRequestHandler<DeleteManhuaCommand>
{
    private readonly DataContext _dataContext;
    private readonly IManhuaService _manhuaService;

    public DeleteManhuaCommandHandler(DataContext dataContext, IManhuaService manhuaService)
    {
        _dataContext = dataContext;
        _manhuaService = manhuaService;
    }

    public async Task Handle(DeleteManhuaCommand request, CancellationToken cancellationToken)
    {
        var manhua = await _dataContext.Manhua.FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($"Манги с идентификатором \"{request.IsnBook}\" не существует");

        _dataContext.Manhua.Remove(manhua);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
