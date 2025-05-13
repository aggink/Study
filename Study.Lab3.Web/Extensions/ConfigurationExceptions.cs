using Study.Lab3.Storage.Enums;

namespace Study.Lab3.Web.Extensions;

public static class ConfigurationExceptions
{
    /// <summary>
    /// Получить провайдер базы данных
    /// </summary>
    /// <param name="configuration">Набор свойств конфигурации</param>
    /// <returns>Провайдер базы данных</returns>
    public static DatabaseProviderType GetDatabaseProvider(this IConfiguration configuration)
    {
        var provider = configuration.GetDatabaseProviderText();

        return provider switch
        {
            "PostgreSql" => DatabaseProviderType.PostgreSql,
            "MSSql" => DatabaseProviderType.MSSql,
            "InMemory" => DatabaseProviderType.InMemory,
            _ => throw new Exception("Провайдер базы данных не задан")
        };
    }

    /// <summary>
    /// Получить провайдер базы данных
    /// </summary>
    /// <param name="configuration">Набор свойств конфигурации</param>
    /// <returns>Провайдер базы данных</returns>
    private static string GetDatabaseProviderText(this IConfiguration configuration)
    {
        var provider = configuration["DatabaseProvider"];

        if (string.IsNullOrEmpty(provider))
            throw new Exception("Провайдер базы данных не задан");

        return provider;
    }
}
