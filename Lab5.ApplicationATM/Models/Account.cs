namespace Lab5.ApplicationATM.Models;

public class Account(Guid accountId, double balance)
{
    public Guid AccountId { get; } = accountId;

    public double Balance { get; } = balance;
}