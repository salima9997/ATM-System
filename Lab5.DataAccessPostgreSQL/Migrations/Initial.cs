using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.DataAccessPostgreSQL.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create table accounts
        (
            account_id uuid,
            balance numeric (100, 2)
        );
        
        create table transactions
        (
            transaction_id bigint primary key generated always as identity,
            account_id uuid,
            transaction text,
            amount numeric(100, 2),
            date text
        );
        
        create table users
        (
            user_name text,
            account_id uuid,
            password int
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table accounts;
        drop table transactions;
        drop table users;
        """;
}