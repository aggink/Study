using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Students.Commands;

/// <summary>
/// Удаление студента
/// </summary>
public sealed class DeleteStudentCommand : IRequest
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnStudent { get; init; }
}

public sealed class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly DataContext _dataContext;

    public DeleteStudentCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _dataContext.Students.FirstOrDefaultAsync(x => x.IsnStudent == request.IsnStudent, cancellationToken)
            ?? throw new BusinessLogicException($"Студента с идентификатором \"{request.IsnStudent}\" не существует");

        _dataContext.Students.Remove(student);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
