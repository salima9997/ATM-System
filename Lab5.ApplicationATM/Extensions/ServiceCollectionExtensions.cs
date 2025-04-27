using Lab5.ApplicationATM.Ports;
using Lab5.ApplicationATM.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.ApplicationATM.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationAtm(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        return collection;
    }
}