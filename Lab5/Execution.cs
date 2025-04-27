using Lab5.ApplicationATM.Extensions;
using Lab5.DataAccessPostgreSQL.Extensions;
using Lab5.PresentationConsole.Extensions;
using Lab5.PresentationConsole.Runners;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();
collection
    .AddApplicationAtm()
    .AddDataAccessPostgreSql(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 5432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();
ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();
scope.UseInfrastructure();
LoginRunner loginRunner = scope.ServiceProvider.GetRequiredService<LoginRunner>();
loginRunner.Execute();