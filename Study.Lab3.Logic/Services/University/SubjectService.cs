using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;
//Обработка предмета
public sealed class SubjectService : ISubjectService
{
    public async Task CreateOrUpdateSubjectAndThrowAsync(
        DataContext dataContext,
        Subject subject,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Subjects.AnyAsync(x => x.IsnSubject != subject.IsnSubject && x.Name == subject.Name, cancellationToken))
            throw new BusinessLogicException($"Предмет с названием \"{subject.IsnSubject}\" уже существует");
    }
}
