using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.Commands;

/// <summary>
/// Создание связи группы с предметом
/// </summary>
public sealed class AddGroupAndSubjectCommand : IRequest
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

public sealed class AddGroupAndSubjectCommandHandler : IRequestHandler<AddGroupAndSubjectCommand>
{
    private readonly DataContext _dataContext;

    public AddGroupAndSubjectCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(AddGroupAndSubjectCommand request, CancellationToken cancellationToken)
    {
        var group = await _dataContext.Groups.FirstOrDefaultAsync(x => x.IsnGroup == request.IsnGroup,
                        cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Группы с идентификатором \"{request.IsnGroup}\" не существует");

        var subject =
            await _dataContext.Subjects.FirstOrDefaultAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken)
            ?? throw new BusinessLogicException($"Предмета с идентификатором \"{request.IsnSubject}\" не существует");

        if (await _dataContext.SubjectsGroups.AnyAsync(
                x => x.IsnGroup == request.IsnGroup && x.IsnSubject == request.IsnSubject, cancellationToken))
            throw new BusinessLogicException(
                $"Группа с идентификатором \"{request.IsnGroup}\" уже привязана к предмету с идентификатором \"{request.IsnSubject}\"");

        var link = new SubjectGroup
        {
            IsnSubject = request.IsnSubject,
            IsnGroup = request.IsnGroup
        };

        await _dataContext.SubjectsGroups.AddAsync(link, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return;
    }
}