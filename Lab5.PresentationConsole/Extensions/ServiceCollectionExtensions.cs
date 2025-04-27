using Lab5.PresentationConsole.Runners;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.PresentationConsole.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<LoginRunner>();
        return collection;
    }
}