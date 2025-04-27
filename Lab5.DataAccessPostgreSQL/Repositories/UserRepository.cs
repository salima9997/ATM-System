using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.ApplicationATM.Models;
using Lab5.ApplicationATM.Ports;
using Npgsql;

namespace Lab5.DataAccessPostgreSQL.Repositories;

public class UserRepository(IPostgresConnectionProvider connectionProvider) : IUserRepository
{
    private IPostgresConnectionProvider ConnectionProvider { get; } = connectionProvider;

    public void AddUser(User user)
    {
        const string sql =
            """
            insert into users (user_name, account_id, password)
            values (:user_name, :account_id, :password);
            """;

        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("user_name", user.Username);
        command.AddParameter("account_id", user.AccountId);
        command.AddParameter("password", user.Password);

        command.ExecuteNonQuery();
    }

    public Guid GetAccountId(string username)
    {
        const string sql =
            """
            select account_id
            from users
            where user_name = :username;
            """;
        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        return reader.GetGuid(0);
    }

    public void CheckUserPassword(string username, int password)
    {
        const string sql =
            """
            select password
            from users
            where user_name = :username;
            """;
        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        if (reader.GetDecimal(0) != password)
        {
            throw new Exception("Wrong password");
        }
    }
}