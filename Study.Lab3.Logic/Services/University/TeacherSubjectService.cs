using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;
//Обработка связей преподаватель-предмет
public sealed class TeacherSubjectService : ITeacherSubjectService
{
    public async Task CreateTeacherSubjectValidateAndThrowAsync(
        DataContext dataContext,
        TeacherSubject teacherSubject,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Teachers.AnyAsync(x => x.IsnTeacher == teacherSubject.IsnTeacher, cancellationToken))
        {
            throw new BusinessLogicException($"Учитель с идентификатором \"{teacherSubject.IsnTeacher}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == teacherSubject.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Предмет с идентификатором \"{teacherSubject.IsnSubject}\" не существует");
        }

        if (await dataContext.TeacherSubjects.AnyAsync(x =>
            x.IsnTeacher == teacherSubject.IsnTeacher &&
            x.IsnSubject == teacherSubject.IsnSubject,
            cancellationToken))
        {
            throw new BusinessLogicException("Такая связь учитель-предмет уже существует");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        TeacherSubject teacherSubject,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Grades.AnyAsync(x =>
            x.IsnSubject == teacherSubject.IsnSubject &&
            dataContext.TeacherSubjects.Any(ts =>
                ts.IsnTeacher == teacherSubject.IsnTeacher &&
                ts.IsnSubject == x.IsnSubject),
            cancellationToken))
        {
            throw new BusinessLogicException("Невозможно удалить связь учитель-предмет, так как существуют оценки по этому предмету");
        }
    }
}