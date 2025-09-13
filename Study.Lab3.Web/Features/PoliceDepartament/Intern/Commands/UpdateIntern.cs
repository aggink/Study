using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Intern.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Intern.Commands;

public sealed class UpdateInternCommand : IRequest<Guid>
{
    [Required]
    [FromBody]
    public UpdateInternDto Intern { get; init; }
}

public sealed class UpdateInternCommandHandler : IRequestHandler<UpdateInternCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IInternService _internService;
    public UpdateInternCommandHandler(DataContext dataContext, IInternService internService)
    {
        _dataContext = dataContext;
        _internService = internService;
    }
    public async Task<Guid> Handle(UpdateInternCommand request, CancellationToken cancellationToken)
    {
        var intern = await _dataContext.Interns.FirstOrDefaultAsync(x => x.IsnIntern == request.Intern.IsnIntern, cancellationToken)
        ?? throw new BusinessLogicException($"Стажера с идентификатором \"{request.Intern.IsnIntern}\" не существует");

        intern.Name = request.Intern.Name;
        intern.SurName = request.Intern.SurName;
        intern.SkillLevel = request.Intern.SkillLevel;

        await _internService.CreateOrUpdateGroupValidateAndThrowAsync(
        _dataContext, intern, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return intern.IsnIntern;
    }
}
