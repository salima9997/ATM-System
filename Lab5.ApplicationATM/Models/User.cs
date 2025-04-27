namespace Lab5.ApplicationATM.Models;

public class User(string username, Guid accountId, int password)
{
    public string Username { get; } = username;

    public Guid AccountId { get; } = accountId;

    public int Password { get; } = password;
}