namespace Lab5.ApplicationATM.Models;

public class Transact(Guid accountId, string transaction, double amount, DateTime date)
{
    public Guid AccountId { get; } = accountId;

    public string Transaction { get; } = transaction;

    public double Amount { get; } = amount;

    public DateTime Date { get; } = date;
}