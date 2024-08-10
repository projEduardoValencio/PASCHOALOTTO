using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RandomUserConsumer.Domain.Interfaces;
using RandomUserConsumer.Domain.Repositories;
using RandomUserConsumer.Infrastructure.DataAccess;
using RandomUserConsumer.Infrastructure.Repositories;

namespace RandomUserConsumer.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IDataBaseInfo databaseInfo)
    {
        AddRepositories(services);
        AddDbContextPosgreSQL(services, databaseInfo);
    }

    private static void AddDbContextPosgreSQL(IServiceCollection services, IDataBaseInfo dataBaseInfo)
    {
        string connectionString =
            $"Host={dataBaseInfo.Host}:{dataBaseInfo.Port};" +
            $"Database={dataBaseInfo.Database};" +
            $"Username={dataBaseInfo.Username};" +
            $"Password={dataBaseInfo.Password};";
    // $"SearchPath={dataBaseInfo.SearchPath};";

        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Using PostgreSQL: {dataBaseInfo.Host}:{dataBaseInfo.Port}...");
        Console.ResetColor();
        
        services.AddDbContext<RandomUserConsumerDbContext>(dbOptions =>
        {
            dbOptions.UseLazyLoadingProxies().UseNpgsql(connectionString);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserWriteRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}