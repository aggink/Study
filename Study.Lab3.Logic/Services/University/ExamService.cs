using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class ExamService : IExamService
{
    public async Task CreateOrUpdateExamValidateAndThrowAsync(
        DataContext dataContext,
        Exam exam,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == exam.IsnSubject, cancellationToken))
            throw new BusinessLogicException($"Предмет с идентификатором \"{exam.IsnSubject}\" не существует");

        if (string.IsNullOrWhiteSpace(exam.Name))
            throw new BusinessLogicException("Название экзамена не может быть пустым");

        if (exam.ExamDate < DateTime.UtcNow)
            throw new BusinessLogicException("Дата экзамена не может быть в прошлом");

        if (exam.Duration < ModelConstants.Exam.MinDuration || exam.Duration > ModelConstants.Exam.MaxDuration)
            throw new BusinessLogicException($"Продолжительность экзамена должна быть от {ModelConstants.Exam.MinDuration} до {ModelConstants.Exam.MaxDuration} минут");

        if (exam.MaxScore < ModelConstants.Exam.MinScore || exam.MaxScore > ModelConstants.Exam.MaxScore)
            throw new BusinessLogicException($"Максимальный балл должен быть от {ModelConstants.Exam.MinScore} до {ModelConstants.Exam.MaxScore}");

        if (exam.PassingScore < ModelConstants.Exam.MinScore || exam.PassingScore > exam.MaxScore)
            throw new BusinessLogicException($"Проходной балл должен быть от {ModelConstants.Exam.MinScore} до {exam.MaxScore}");

        if (await dataContext.Exams.AnyAsync(x =>
            x.IsnSubject == exam.IsnSubject &&
            x.Name == exam.Name &&
            x.IsnExam != exam.IsnExam,
            cancellationToken))
            throw new BusinessLogicException($"Экзамен с названием \"{exam.Name}\" уже существует для данного предмета");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Exam exam,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Exams.AnyAsync(x => x.IsnExam == exam.IsnExam, cancellationToken))
            throw new BusinessLogicException($"Экзамен с идентификатором \"{exam.IsnExam}\" не существует");

        if (await dataContext.ExamRegistrations.AnyAsync(x => x.IsnExam == exam.IsnExam, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить экзамен, так как на него есть регистрации");
    }
}
