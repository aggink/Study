using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Storage.MS_SQL
{
    public class MicrosoftSqlContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private const string DbConnectionString = "Server=localhost,1433;Database=Study;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";

        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();

            optionBuilder.UseSqlServer(DbConnectionString, b => b.MigrationsAssembly(typeof(MicrosoftSqlContextFactory).Namespace));

            return new DataContext(optionBuilder.Options);
        }
    }
}
