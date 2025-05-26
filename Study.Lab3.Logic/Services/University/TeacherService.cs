using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;
//Обработка преподавателя
public sealed class TeacherService : ITeacherService
{
    public async Task CreateOrUpdateTeacherValidateAndThrowAsync(
        DataContext dataContext,
        Teacher teacher,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Teachers.AnyAsync(x =>
            x.IsnTeacher != teacher.IsnTeacher &&
            x.SurName == teacher.SurName &&
            x.Name == teacher.Name &&
            x.PatronymicName == teacher.PatronymicName,
            cancellationToken))
        {
            throw new BusinessLogicException(
                $"Учитель с ФИО \"{teacher.SurName} {teacher.Name} {teacher.PatronymicName}\" уже существует");
        }

        if (string.IsNullOrWhiteSpace(teacher.SurName) ||
            string.IsNullOrWhiteSpace(teacher.Name) ||
            string.IsNullOrWhiteSpace(teacher.PatronymicName))
        {
            throw new BusinessLogicException("ФИО учителя не может быть пустым");
        }

        if (teacher.SurName.Length > ModelConstants.Teacher.SurName ||
            teacher.Name.Length > ModelConstants.Teacher.Name ||
            teacher.PatronymicName.Length > ModelConstants.Teacher.PatronymicName)
        {
            throw new BusinessLogicException("Превышена максимальная длина ФИО");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Teacher teacher,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.TeacherSubjects.AnyAsync(x => x.IsnTeacher == teacher.IsnTeacher, cancellationToken))
        {
            throw new BusinessLogicException($"Учитель не может быть удален, т.к. за ним закреплены предметы");
        }
    }
}