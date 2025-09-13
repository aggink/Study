using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Officer.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Officer.Commands;

public sealed class CreateOfficerCommand : IRequest<Guid>
{
    [FromBody]
    [Required]
    public CreateOfficerDto Officer { get; init; }
}
public sealed class CreateOfficerCommandHandler : IRequestHandler<CreateOfficerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOfficerService _officerService;
    public CreateOfficerCommandHandler(DataContext dataContext, IOfficerService officerService)
    {
        _officerService = officerService;
        _dataContext = dataContext;
    }
    public async Task<Guid> Handle(CreateOfficerCommand request, CancellationToken cancellationToken)
    {
        var officer = new Storage.Models.PoliceDepartament.Officer
        {
            IsnOfficer = Guid.NewGuid(),
            Name = request.Officer.Name,
            SurName = request.Officer.SurName,
            Rank = request.Officer.Rank
        };

        await _officerService.CreateOrUpdateGroupValidateAndThrowAsync(
        _dataContext, officer, cancellationToken);
        await _dataContext.Officers.AddAsync(officer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return officer.IsnOfficer;
    }
}
