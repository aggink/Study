using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Intern.Commands;

public sealed class DeleteInternCommand : IRequest
{
    [Required]
    [FromQuery]
    public Guid IsnIntern { get; init; }
}
public sealed class DeleteInternCommandHandler : IRequestHandler<DeleteInternCommand>
{
    private readonly DataContext _dataContext;
    private readonly IInternService _internService;

    public DeleteInternCommandHandler(DataContext dataContext, IInternService internService)
    {
        _dataContext = dataContext;
        _internService = internService;
    }
    public async Task Handle(DeleteInternCommand request, CancellationToken cancellationToken)
    {
        var intern = await _dataContext.Interns.FirstOrDefaultAsync(x => x.IsnIntern == request.IsnIntern, cancellationToken)
        ?? throw new BusinessLogicException($"Стажера с идентификатором \"{request.IsnIntern}\" не существует");

        _dataContext.Interns.Remove(intern);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
