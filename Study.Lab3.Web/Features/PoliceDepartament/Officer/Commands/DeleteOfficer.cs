using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Officer.Commands;

public sealed class DeleteOfficerCommand : IRequest
{
    [Required]
    [FromQuery]
    public Guid IsnOfficer { get; init; }
}
public sealed class DeleteOfficerCommandHandler : IRequestHandler<DeleteOfficerCommand>
{
    private readonly DataContext _dataContext;
    private readonly IOfficerService _officerService;

    public DeleteOfficerCommandHandler(DataContext dataContext, IOfficerService officerService)
    {
        _dataContext = dataContext;
        _officerService = officerService;
    }
    public async Task Handle(DeleteOfficerCommand request, CancellationToken cancellationToken)
    {
        var officer = await _dataContext.Officers.FirstOrDefaultAsync(x => x.IsnOfficer == request.IsnOfficer, cancellationToken)
        ?? throw new BusinessLogicException($"Офицера с идентификатором \"{request.IsnOfficer}\" не существует");

        _dataContext.Officers.Remove(officer);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
