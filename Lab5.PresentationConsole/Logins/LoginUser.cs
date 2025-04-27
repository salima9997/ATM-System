using Lab5.ApplicationATM.Ports;
using Lab5.PresentationConsole.Runners;

namespace Lab5.PresentationConsole.Logins;

public class LoginUser(IAccountService accountService) : Login(accountService)
{
    public override string Name() => "User";

    public override void Run()
    {
        var scenarioRunner = new ScenarioRunner(GetAccountService());
        while (true)
        {
            scenarioRunner.Execute();
        }
    }
}