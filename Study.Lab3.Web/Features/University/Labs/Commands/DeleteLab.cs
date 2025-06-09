using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Groups.Commands;

/// <summary>
/// Удаление группы
/// </summary>
public sealed class DeleteLabCommand : IRequest
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnLab { get; init; }
}

public sealed class DeleteLabCommandHandler : IRequestHandler<DeleteLabCommand>
{
    private readonly DataContext _dataContext;
    private readonly ILabService _labService;

    public DeleteLabCommandHandler(
        DataContext dataContext,
        ILabService labService)
    {
        _dataContext = dataContext;
        _labService = labService;
    }

    public async Task Handle(DeleteLabCommand request, CancellationToken cancellationToken)
    {
        var lab = await _dataContext.Labs.FirstOrDefaultAsync(x => x.IsnLab == request.IsnLab, cancellationToken)
            ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.IsnLab}\" не существует");


        _dataContext.Labs.Remove(lab);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
