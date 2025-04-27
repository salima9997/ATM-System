using Lab5.ApplicationATM.Models;

namespace Lab5.ApplicationATM.Ports;

public interface ITransactionRepository
{
    public void AddTransaction(Transact transact);

    public ICollection<string> ShowTransactionHistory(Guid accountId);
}