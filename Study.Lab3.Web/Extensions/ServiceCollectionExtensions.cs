using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Extensions;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.PostgreSQL;

namespace Study.Lab3.Web.Extensions;

/// <summary>
/// Расширения для <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация служб приложения
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddServiceCollection(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        services.AddLogicServiceCollection();
    }

    /// <summary>
    /// Регистрация контекста базы данных
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <param name="configuration">Набор свойств конфигурации</param>
    public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), o =>
            {
                o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                o.MigrationsAssembly(typeof(PostgreSqlContextFactory).Namespace);
            });
        });
    }
}
