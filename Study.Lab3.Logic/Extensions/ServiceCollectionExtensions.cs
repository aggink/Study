using Microsoft.Extensions.DependencyInjection;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Logic.Services.University;

namespace Study.Lab3.Logic.Extensions;

/// <summary>
/// Расширения для <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация сервисов библиотеки Logic
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddLogicServiceCollection(this IServiceCollection services)
    {
        services.AddSingleton<IGroupService, GroupService>();
        services.AddSingleton<ISubjectService, SubjectService>();
    }
}
