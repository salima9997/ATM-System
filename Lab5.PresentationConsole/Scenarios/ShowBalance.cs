using Lab5.ApplicationATM.Ports;
using Spectre.Console;

namespace Lab5.PresentationConsole.Scenarios;

public class ShowBalance(IAccountService accountService) : Scenario(accountService)
{
    public override string ScenarioName() => "Show Balance";

    public override void Run()
    {
        string username = GetAccountService().GetCurrentUser();
        if (string.IsNullOrEmpty(username))
        {
            username = AnsiConsole.Ask<string>("Enter username: ");
            int password = int.Parse(AnsiConsole.Prompt(new TextPrompt<string>("Enter password: ").Secret()));
            GetAccountService().CheckUserPassword(username, password);
            GetAccountService().ChangeCurrentUser(username);
        }

        double balance = GetAccountService().ShowBalance(username);
        AnsiConsole.MarkupLine($"Balance: {balance}");
    }
}