using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.ApplicationATM.Models;
using Lab5.ApplicationATM.Ports;
using Npgsql;

namespace Lab5.DataAccessPostgreSQL.Repositories;

public class AccountRepository(IPostgresConnectionProvider connectionProvider) : IAccountRepository
{
    private IPostgresConnectionProvider ConnectionProvider { get; } = connectionProvider;

    public void AddAccount(Account account)
    {
        const string sql =
            """
            insert into accounts (account_id, balance)
            values (:account_id, :balance);
            """;

        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", account.AccountId);
        command.AddParameter("balance", account.Balance);

        command.ExecuteNonQuery();
    }

    public double ShowBalance(Guid accountId)
    {
        const string sql =
            """
            select balance
            from accounts
            where account_id = :account_id;
            """;
        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", accountId);
        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        return reader.GetDouble(0);
    }

    public void Replenishment(Guid accountId, double amount)
    {
        const string sql =
            """
            update accounts
            set balance = balance + :amount
            where account_id = :account_id;
            """;
        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", accountId);
        command.AddParameter("amount", amount);
        command.ExecuteNonQuery();
    }

    public void Withdraw(Guid accountId, double amount)
    {
        if (amount > ShowBalance(accountId))
        {
            throw new Exception("Not enough money");
        }

        const string sql =
            """
            update accounts
            set balance = balance - :amount
            where account_id = :account_id;
            """;
        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", accountId);
        command.AddParameter("amount", amount);
        command.ExecuteNonQuery();
    }
}