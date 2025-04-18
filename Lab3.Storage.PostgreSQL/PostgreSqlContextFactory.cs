using Lab3.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab3.Storage.PostgreSQL
{
    public class PostgreSqlContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private const string DbConnectionString = "Host=localhost:54320;Database=Study;Username=user_developer;Password=user_developer;CommandTimeout=20;Timeout=40;Include Error Detail=True";

        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();

            optionBuilder.UseNpgsql(DbConnectionString, b => b.MigrationsAssembly(typeof(PostgreSqlContextFactory).Namespace));

            return new DataContext(optionBuilder.Options);
        }
    }
}
