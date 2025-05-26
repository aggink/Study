/*using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class AssignmentService : IAssignmentService
{
    public async Task CreateOrUpdateAssignmentValidateAndThrowAsync(
        DataContext dataContext,
        Assignment assignment,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == assignment.IsnSubject, cancellationToken))
            throw new BusinessLogicException($"Предмет с идентификатором \"{assignment.IsnSubject}\" не существует");

        if (string.IsNullOrWhiteSpace(assignment.Title))
            throw new BusinessLogicException("Название задания не может быть пустым");

        if (string.IsNullOrWhiteSpace(assignment.Description))
            throw new BusinessLogicException("Описание задания не может быть пустым");

        if (assignment.MaxScore <= 0)
            throw new BusinessLogicException("Максимальная оценка должна быть положительным числом");

        if (assignment.Deadline.HasValue && assignment.Deadline.Value < assignment.PublishDate)
            throw new BusinessLogicException("Крайний срок выполнения не может быть раньше даты публикации");

        if (await dataContext.Assignments.AnyAsync(
                x => x.IsnSubject == assignment.IsnSubject &&
                     x.Title == assignment.Title &&
                     x.IsnAssignment != assignment.IsnAssignment,
                cancellationToken))
            throw new BusinessLogicException(
                $"Задание с названием \"{assignment.Title}\" уже существует для данного предмета");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Assignment assignment,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Assignments.AnyAsync(x => x.IsnAssignment == assignment.IsnAssignment, cancellationToken))
            throw new BusinessLogicException($"Задание с идентификатором \"{assignment.IsnAssignment}\" не существует");
    }
}*/