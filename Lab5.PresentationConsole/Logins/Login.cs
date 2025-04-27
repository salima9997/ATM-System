using Lab5.ApplicationATM.Ports;

namespace Lab5.PresentationConsole.Logins;

public abstract class Login(IAccountService accountService)
{
    private IAccountService AccountService { get; } = accountService;

    public IAccountService GetAccountService() => AccountService;

    public abstract string Name();

    public abstract void Run();
}