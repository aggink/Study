using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.Commands;

/// <summary>
/// Удаление группы
/// </summary>
public sealed class DeleteStudentLabCommand : IRequest
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnStudentLab { get; init; }
}

public sealed class DeleteStudentLabCommandHandler : IRequestHandler<DeleteStudentLabCommand>
{
    private readonly DataContext _dataContext;
    private readonly ILabService _labService;

    public DeleteStudentLabCommandHandler(
        DataContext dataContext,
        ILabService labService)
    {
        _dataContext = dataContext;
        _labService = labService;
    }

    public async Task Handle(DeleteStudentLabCommand request, CancellationToken cancellationToken)
    {
        var studentlab = await _dataContext.StudentLab.FirstOrDefaultAsync(x => x.IsnStudentLab == request.IsnStudentLab, cancellationToken)
            ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.IsnStudentLab}\" не существует");


        _dataContext.StudentLab.Remove(studentlab);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
