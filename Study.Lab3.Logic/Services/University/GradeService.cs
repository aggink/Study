using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;
//Обработка оценок
public sealed class GradeService : IGradeService
{
    public async Task CreateOrUpdateGradeValidateAndThrowAsync(
        DataContext dataContext,
        Grade grade,
        Guid teacherId,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == grade.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{grade.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == grade.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Предмет с идентификатором \"{grade.IsnSubject}\" не существует");
        }

        if (grade.Value < ModelConstants.Grade.MinValue || grade.Value > ModelConstants.Grade.MaxValue)
        {
            throw new BusinessLogicException($"Значение оценки должно быть от {ModelConstants.Grade.MinValue} до {ModelConstants.Grade.MaxValue}");
        }

        if (!await dataContext.TeacherSubjects.AnyAsync(
            x => x.IsnTeacher == teacherId && x.IsnSubject == grade.IsnSubject,
            cancellationToken))
        {
            throw new BusinessLogicException("У вас нет прав на выставление оценок по данному предмету");
        }

        if (grade.GradeDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя выставить оценку будущим числом");
        }

        var existingGrade = await dataContext.Grades
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == grade.IsnStudent &&
                x.IsnSubject == grade.IsnSubject &&
                x.GradeDate.Date == grade.GradeDate.Date &&
                x.IsnGrade != grade.IsnGrade,
                cancellationToken);

        if (existingGrade != null)
        {
            throw new BusinessLogicException("У студента уже есть оценка по этому предмету в указанную дату");
        }

        if (grade.IsnGrade != Guid.Empty)
        {
            var originalGrade = await dataContext.Grades
                .FirstOrDefaultAsync(x => x.IsnGrade == grade.IsnGrade, cancellationToken);

            if (originalGrade != null &&
                (DateTime.UtcNow - originalGrade.GradeDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить оценку, выставленную более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Grade grade,
        Guid teacherId,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.TeacherSubjects.AnyAsync(
            x => x.IsnTeacher == teacherId && x.IsnSubject == grade.IsnSubject,
            cancellationToken))
        {
            throw new BusinessLogicException("У вас нет прав на удаление оценок по данному предмету");
        }

        if ((DateTime.UtcNow - grade.GradeDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить оценку, выставленную более месяца назад");
        }

        var hasAttestation = await dataContext.Grades
            .AnyAsync(x =>
                x.IsnStudent == grade.IsnStudent &&
                x.IsnSubject == grade.IsnSubject &&
                x.GradeDate > grade.GradeDate,
                cancellationToken);

        if (hasAttestation)
        {
            throw new BusinessLogicException("Нельзя удалить оценку, так как уже есть более поздние оценки по предмету");
        }
    }
}