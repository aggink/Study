using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.University;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class ExamResultService : IExamResultService
{
    public async Task CreateOrUpdateResultValidateAndThrowAsync(
        DataContext dataContext,
        ExamResult result,
        CancellationToken cancellationToken = default)
    {
        var registration = await dataContext.ExamRegistrations
            .Include(x => x.Exam)
            .FirstOrDefaultAsync(x => x.IsnExamRegistration == result.IsnExamRegistration, cancellationToken)
            ?? throw new BusinessLogicException($"Регистрация с идентификатором \"{result.IsnExamRegistration}\" не существует");

        if (registration.Status != RegistrationStatus.Completed)
            throw new BusinessLogicException("Невозможно добавить результат для незавершенной регистрации");

        if (result.Score < ModelConstants.ExamResult.MinScore || result.Score > ModelConstants.ExamResult.MaxScore)
            throw new BusinessLogicException($"Балл должен быть от {ModelConstants.ExamResult.MinScore} до {ModelConstants.ExamResult.MaxScore}");

        // Автоматическое определение, сдан ли экзамен
        result.IsPassed = result.Score >= registration.Exam.PassingScore;

        if (await dataContext.ExamResults.AnyAsync(x =>
            x.IsnExamRegistration == result.IsnExamRegistration &&
            x.IsnExamResult != result.IsnExamResult,
            cancellationToken))
            throw new BusinessLogicException("Результат для этой регистрации уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ExamResult result,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.ExamResults.AnyAsync(x => x.IsnExamResult == result.IsnExamResult, cancellationToken))
            throw new BusinessLogicException($"Результат с идентификатором \"{result.IsnExamResult}\" не существует");

        var registration = await dataContext.ExamRegistrations
            .Include(x => x.Exam)
            .FirstOrDefaultAsync(x => x.IsnExamRegistration == result.IsnExamRegistration, cancellationToken);

        if (registration != null &&
            (DateTime.UtcNow - registration.Exam.ExamDate).TotalDays > 30)
            throw new BusinessLogicException("Невозможно удалить результат экзамена, прошедшего более 30 дней назад");
    }
}
