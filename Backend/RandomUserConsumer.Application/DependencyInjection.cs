using Microsoft.Extensions.DependencyInjection;
using RandomUserConsumer.Application.Interfaces;
using RandomUserConsumer.Application.Services;
using RandomUserConsumer.Application.UseCases.User;
using RandomUserConsumer.Domain.Entities;

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
        services.AddScoped<AddressService>();
        services.AddScoped<AccountService>();
        services.AddScoped<ContactService>();
        services.AddScoped<CoordinateService>();
        services.AddScoped<LoginService>();
    }
}