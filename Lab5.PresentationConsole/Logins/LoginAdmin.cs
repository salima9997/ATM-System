using Lab5.ApplicationATM.Ports;
using Lab5.PresentationConsole.Runners;
using Spectre.Console;

namespace Lab5.PresentationConsole.Logins;

public class LoginAdmin(IAccountService accountService) : Login(accountService)
{
    public override string Name() => "Administrator";

    public override void Run()
    {
        int systemPassword = int.Parse(AnsiConsole.Prompt(new TextPrompt<string>("Enter system password: ").Secret()));
        if (GetAccountService().CheckSystemPassword(systemPassword))
        {
            var scenarioRunner = new ScenarioRunner(GetAccountService());
            while (true)
            {
                scenarioRunner.Execute();
            }
        }
    }
}