using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Officer.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Officer.Commands;

public sealed class UpdateOfficerCommand : IRequest<Guid>
{
    [Required]
    [FromBody]
    public UpdateOfficerDto Officer { get; init; }
}

public sealed class UpdateOfficerCommandHandler : IRequestHandler<UpdateOfficerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOfficerService _officerService;
    public UpdateOfficerCommandHandler(DataContext dataContext, IOfficerService officerService)
    {
        _dataContext = dataContext;
        _officerService = officerService;
    }
    public async Task<Guid> Handle(UpdateOfficerCommand request, CancellationToken cancellationToken)
    {
        var officer = await _dataContext.Officers.FirstOrDefaultAsync(x => x.IsnOfficer == request.Officer.IsnOfficer, cancellationToken)
        ?? throw new BusinessLogicException($"Офицера с идентификатором \"{request.Officer.IsnOfficer}\" не существует");

        officer.Name = request.Officer.Name;
        officer.SurName = request.Officer.SurName;
        officer.Rank = request.Officer.Rank;

        await _officerService.CreateOrUpdateGroupValidateAndThrowAsync(
        _dataContext, officer, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return officer.IsnOfficer;
    }
}
