using Lab5.ApplicationATM.Ports;
using Spectre.Console;

namespace Lab5.PresentationConsole.Scenarios;

public class CreateAccount(IAccountService accountService) : Scenario(accountService)
{
    public override string ScenarioName() => "Create Account";

    public override void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter username: ");
        int password = int.Parse(AnsiConsole.Prompt(new TextPrompt<string>("Enter your password: ").Secret()));
        GetAccountService().CreateAccount(username, password);
        AnsiConsole.MarkupLine("[green]Success![/]");
    }
}