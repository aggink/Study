using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class LabService : ILabService
{
    public async Task CreateOrUpdateLabValidateAndThrowAsync(
        DataContext dataContext,
        Labs lab,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Labs.AnyAsync(x => x.IsnLab != lab.IsnLab && x.Name == lab.Name, cancellationToken))
            throw new BusinessLogicException($"Группа с именем \"{lab.Name}\" уже создана");
    }
    public async Task CreateOrUpdateStudentLabValidateAndThrowAsync(
        DataContext dataContext,
        StudentLab studentlab,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.StudentLab.AnyAsync(x => x.IsnStudent == studentlab.IsnStudent && x.IsnLab == studentlab.IsnLab, cancellationToken))
            throw new BusinessLogicException($"Оценка уже создана");
    }

}
