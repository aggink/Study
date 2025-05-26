using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Extensions;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums;
using Study.Lab3.Storage.MS_SQL;
using Study.Lab3.Storage.PostgreSQL;

namespace Study.Lab3.Web.Extensions;
//Настройка провайдеров и инициализация
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
        services.AddLogicServiceCollection();
    }

    /// <summary>
    /// Регистрация контекста базы данных
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <param name="configuration">Набор свойств конфигурации</param>
    public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        var dbProvider = configuration.GetDatabaseProvider();

        if (dbProvider == DatabaseProviderType.PostgreSql)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSql"), o =>
                {
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    o.MigrationsAssembly(typeof(PostgreSqlContextFactory).Namespace);
                });
            });
        }
        else if (dbProvider == DatabaseProviderType.MSSql)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSql"), o =>
                {
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    o.MigrationsAssembly(typeof(MicrosoftSqlContextFactory).Namespace);
                });
            });
        }
        else if (dbProvider == DatabaseProviderType.InMemory)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("Study", o =>
                {
                    o.EnableNullChecks();
                });
            });
        }
    }
}
