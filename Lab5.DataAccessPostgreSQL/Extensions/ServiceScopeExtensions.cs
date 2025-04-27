using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.DataAccessPostgreSQL.Extensions;

public static class ServiceScopeExtensions
{
    public static void UseInfrastructure(this IServiceScope scope)
    {
        scope.UsePlatformMigrationsAsync(default).GetAwaiter().GetResult();
    }
}