using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace StudentMangementSystem.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var builder = new DbContextOptionsBuilder<RepositoryContext>().UseNpgsql(configuration.GetConnectionString("postgresqlConnection"),
        b => b.MigrationsAssembly("StudentMangementSystem"));

        return new RepositoryContext(builder.Options);
    }
}
