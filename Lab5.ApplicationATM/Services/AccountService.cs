using Lab5.ApplicationATM.Models;
using Lab5.ApplicationATM.Ports;

namespace Lab5.ApplicationATM.Services;

public class AccountService(
    IUserRepository userRepository,
    IAccountRepository accountRepository,
    ITransactionRepository transactionRepository) : IAccountService
{
    private IUserRepository UserRepository { get; } = userRepository;

    private IAccountRepository AccountRepository { get; } = accountRepository;

    private ITransactionRepository TransactionRepository { get; } = transactionRepository;

    private CurrentUser CurrentUserr { get; set; } = new();

    private SystemPassword SystemPasswordd { get; set; } = new();

    public void CreateAccount(string username, int password)
    {
        var accountId = Guid.NewGuid();
        var user = new User(username, accountId, password);
        var account = new Account(accountId, 0);

        UserRepository.AddUser(user);
        AccountRepository.AddAccount(account);
        ChangeCurrentUser(username);
    }

    public double ShowBalance(string username)
    {
        Guid accountId = UserRepository.GetAccountId(username);
        return AccountRepository.ShowBalance(accountId);
    }

    public ICollection<string> ShowTransactionHistory(string username)
    {
        Guid accountId = UserRepository.GetAccountId(username);
        return TransactionRepository.ShowTransactionHistory(accountId);
    }

    public void Replenishment(string username, double amount)
    {
        Guid accountId = UserRepository.GetAccountId(username);
        string str = "replenishment";
        var transaction = new Transact(accountId, str, amount, DateTime.Now);

        TransactionRepository.AddTransaction(transaction);
        AccountRepository.Replenishment(accountId, amount);
    }

    public void Withdraw(string username, double amount)
    {
        Guid accountId = UserRepository.GetAccountId(username);
        string str = "withdraw";
        var transaction = new Transact(accountId, str, amount, DateTime.Now);

        TransactionRepository.AddTransaction(transaction);
        AccountRepository.Withdraw(accountId, amount);
    }

    public void ChangeCurrentUser(string username)
    {
        CurrentUserr.Username = username;
    }

    public string GetCurrentUser() => CurrentUserr.Username;

    public bool CheckSystemPassword(int systemPassword)
    {
        if (systemPassword != SystemPasswordd.Password) return false;
        return true;
    }

    public void CheckUserPassword(string username, int password)
    {
        UserRepository.CheckUserPassword(username, password);
    }
}