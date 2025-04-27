using Lab5.ApplicationATM.Models;

namespace Lab5.ApplicationATM.Ports;

public interface IAccountRepository
{
    public void AddAccount(Account account);

    public double ShowBalance(Guid accountId);

    public void Replenishment(Guid accountId, double amount);

    public void Withdraw(Guid accountId, double amount);
}