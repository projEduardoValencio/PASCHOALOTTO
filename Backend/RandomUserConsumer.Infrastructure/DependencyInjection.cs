using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RandomUserConsumer.Domain.Interfaces;
using RandomUserConsumer.Domain.Interfaces.Repositories.Account;
using RandomUserConsumer.Domain.Interfaces.Repositories.Address;
using RandomUserConsumer.Domain.Interfaces.Repositories.Contact;
using RandomUserConsumer.Domain.Interfaces.Repositories.Coordinate;
using RandomUserConsumer.Domain.Interfaces.Repositories.Login;
using RandomUserConsumer.Domain.Interfaces.Repositories.User;
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
        
        services.AddScoped<IAccountWriteRepository, AccountRepository>();
        services.AddScoped<IAccountReadOnlyRepository, AccountRepository>();
        
        services.AddScoped<IAddressWriteRepository, AddressRepository>();
        services.AddScoped<IAddressReadOnlyRepository, AddressRepository>();
        
        services.AddScoped<IContactWriteRepository, ContactRepository>();
        services.AddScoped<IContactReadOnlyRepository, ContactRepository>();
        
        services.AddScoped<ICoordinateWriteRepository, CoordinateRepository>();
        services.AddScoped<ICoordinateReadOnlyRepository, CoordinateRepository>();
        
        services.AddScoped<ILoginWriteRepository, LoginRepository>();
        services.AddScoped<ILoginReadOnlyRepository, LoginRepository>();
    }
}