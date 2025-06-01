using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.University;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class ExamRegistrationService : IExamRegistrationService
{
    public async Task CreateOrUpdateRegistrationValidateAndThrowAsync(
        DataContext dataContext,
        ExamRegistration registration,
        CancellationToken cancellationToken = default)
    {
        var exam = await dataContext.Exams.FirstOrDefaultAsync(x => x.IsnExam == registration.IsnExam, cancellationToken)
            ?? throw new BusinessLogicException($"Экзамен с идентификатором \"{registration.IsnExam}\" не существует");

        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == registration.IsnStudent, cancellationToken))
            throw new BusinessLogicException($"Студент с идентификатором \"{registration.IsnStudent}\" не существует");

        if (registration.RegistrationDate > exam.ExamDate)
            throw new BusinessLogicException("Дата регистрации не может быть позже даты экзамена");

        if (await dataContext.ExamRegistrations.AnyAsync(x =>
            x.IsnExam == registration.IsnExam &&
            x.IsnStudent == registration.IsnStudent &&
            x.IsnExamRegistration != registration.IsnExamRegistration,
            cancellationToken))
            throw new BusinessLogicException("Студент уже зарегистрирован на этот экзамен");

        if (exam.ExamDate < DateTime.UtcNow && registration.Status == RegistrationStatus.Registered)
            throw new BusinessLogicException("Нельзя зарегистрироваться на прошедший экзамен");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ExamRegistration registration,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.ExamRegistrations.AnyAsync(x => x.IsnExamRegistration == registration.IsnExamRegistration, cancellationToken))
            throw new BusinessLogicException($"Регистрация с идентификатором \"{registration.IsnExamRegistration}\" не существует");

        if (await dataContext.ExamResults.AnyAsync(x => x.IsnExamRegistration == registration.IsnExamRegistration, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить регистрацию, так как существует результат экзамена");

        var exam = await dataContext.Exams.FirstOrDefaultAsync(x => x.IsnExam == registration.IsnExam, cancellationToken);
        if (exam != null && exam.ExamDate < DateTime.UtcNow)
            throw new BusinessLogicException("Невозможно удалить регистрацию на прошедший экзамен");
    }
}
