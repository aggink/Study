using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.Commands;

/// <summary>
/// Удаление предмета
/// </summary>
public sealed class DeleteSubjectCommand : IRequest
{
    [Required][FromQuery] public Guid IsnSubject { get; init; }
}

public sealed class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand>
{
    private readonly DataContext _dataContext;

    public DeleteSubjectCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject =
            await _dataContext.Subjects.FirstOrDefaultAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken)
            ?? throw new BusinessLogicException($"Предмета с идентификатором \"{request.IsnSubject}\" не существует");

        _dataContext.Subjects.Remove(subject);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}