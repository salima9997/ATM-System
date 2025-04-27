using Lab5.ApplicationATM.Models;

namespace Lab5.ApplicationATM.Ports;

public interface IUserRepository
{
    public void AddUser(User user);

    public Guid GetAccountId(string username);

    public void CheckUserPassword(string username, int password);
}