using Lab5.ApplicationATM.Ports;

namespace Lab5.PresentationConsole.Scenarios;

public abstract class Scenario(IAccountService accountService)
{
    private IAccountService AccountService { get; } = accountService;

    public IAccountService GetAccountService() => AccountService;

    public abstract string ScenarioName();

    public abstract void Run();
}