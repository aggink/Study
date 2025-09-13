using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Intern.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Intern.Commands;

public sealed class CreateInternCommand : IRequest<Guid>
{
    [FromBody]
    [Required]
    public CreateInternDto Intern { get; init; }
}
public sealed class CreateInternCommandHandler : IRequestHandler<CreateInternCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IInternService _internService;
    public CreateInternCommandHandler(DataContext dataContext, IInternService internService)
    {
        _internService = internService;
        _dataContext = dataContext;
    }
    public async Task<Guid> Handle(CreateInternCommand request, CancellationToken cancellationToken)
    {
        var intern = new Storage.Models.PoliceDepartament.Intern
        {
            IsnIntern = Guid.NewGuid(),
            Name = request.Intern.Name,
            SurName = request.Intern.SurName,
            SkillLevel = request.Intern.SkillLevel
        };

        await _internService.CreateOrUpdateGroupValidateAndThrowAsync(
        _dataContext, intern, cancellationToken);
        await _dataContext.Interns.AddAsync(intern, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return intern.IsnIntern;
    }
}
