using Microsoft.Extensions.DependencyInjection;
using RandomUserConsumer.Application.Interfaces;
using RandomUserConsumer.Application.UseCases.User;

namespace RandomUserConsumer.Application;

public static class DependencyInjection
{
    public static void AddApplicationServcices(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IUserUserCase, UserUseCase>();
    }
}