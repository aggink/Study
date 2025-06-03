using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Storage.PostgreSQL;

/// <summary>
/// Фабрика для создания экземпляров <see cref="DataContext"/> во время проектирования.
/// Используется для настройки и инициализации контекста базы данных PostgreSQL в средах разработки, таких как миграции и инструменты командной строки.
/// </summary>
public class PostgreSqlContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    private const string DbConnectionString = "Host=localhost:5432;Database=postgres;Username=postgres;Password=123456;CommandTimeout=20;Timeout=40;Include Error Detail=True";

    public DataContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();

        optionBuilder.UseNpgsql(DbConnectionString, b => b.MigrationsAssembly(typeof(PostgreSqlContextFactory).Namespace));

        return new DataContext(optionBuilder.Options);
    }
}
