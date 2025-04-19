using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.Commands;

/// <summary>
/// Удаление связи группы с предметом
/// </summary>
public sealed class DeleteGroupAndSubjectCommand : IRequest
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    public Guid IsnGroup { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }
}

public sealed class DeleteGroupAndSubjectCommandHandler : IRequestHandler<DeleteGroupAndSubjectCommand>
{
    private readonly DataContext _dataContext;

    public DeleteGroupAndSubjectCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteGroupAndSubjectCommand request, CancellationToken cancellationToken)
    {
        var group = await _dataContext.Groups.FirstOrDefaultAsync(x => x.IsnGroup == request.IsnGroup, cancellationToken)
            ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.IsnGroup}\" не существует");

        var subject = await _dataContext.Subjects.FirstOrDefaultAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken)
            ?? throw new BusinessLogicException($"Предмета с идентификатором \"{request.IsnSubject}\" не существует");

        var link = await _dataContext.SubjectsGroups.FirstOrDefaultAsync(x => x.IsnGroup == request.IsnGroup && x.IsnSubject == request.IsnSubject)
            ?? throw new BusinessLogicException($"Группа с идентификатором \"{request.IsnGroup}\" не привязана к предмету с идентификатором \"{request.IsnSubject}\"");

        _dataContext.SubjectsGroups.Remove(link);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return;
    }
}
