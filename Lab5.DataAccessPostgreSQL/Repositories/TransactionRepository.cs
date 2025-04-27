using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.ApplicationATM.Models;
using Lab5.ApplicationATM.Ports;
using Npgsql;

namespace Lab5.DataAccessPostgreSQL.Repositories;

public class TransactionRepository(IPostgresConnectionProvider connectionProvider) : ITransactionRepository
{
    private IPostgresConnectionProvider ConnectionProvider { get; } = connectionProvider;

    public void AddTransaction(Transact transact)
    {
        const string sql =
            """
            insert into transactions (transaction_id, account_id, transaction, amount, date)
            values (default, :account_id, :transaction, :amount, :date);
            """;

        NpgsqlConnection connection = ConnectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", transact.AccountId);
        command.AddParameter("transaction", transact.Transaction);
        command.AddParameter("amount", transact.Amount);
        command.AddParameter("date", transact.Date);

        command.ExecuteNonQuery();
    }

    public ICollection<string> ShowTransactionHistory(Guid accountId)
    {
        const string sql =
            """
            select *
            from transactions
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
        var history = new List<string>();
        while (reader.Read())
        {
            string transaction = reader.GetString(2) + "    " + reader.GetDouble(3) + "    " + reader.GetString(4) + '\n';
            history.Add(transaction);
        }

        return history;
    }
}