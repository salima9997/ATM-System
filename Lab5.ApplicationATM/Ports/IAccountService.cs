namespace Lab5.ApplicationATM.Ports;

public interface IAccountService
{
    public void CreateAccount(string username, int password);

    public double ShowBalance(string username);

    public ICollection<string> ShowTransactionHistory(string username);

    public void Replenishment(string username, double amount);

    public void Withdraw(string username, double amount);

    public void ChangeCurrentUser(string username);

    public string GetCurrentUser();

    public bool CheckSystemPassword(int systemPassword);

    public void CheckUserPassword(string username, int password);
}