using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Lab5.ApplicationATM.Ports;
using Lab5.DataAccessPostgreSQL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.DataAccessPostgreSQL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessPostgreSql(this IServiceCollection collection, Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatform();
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);
        collection.AddScoped<IAccountRepository, AccountRepository>();
        collection.AddScoped<ITransactionRepository, TransactionRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();
        return collection;
    }
}