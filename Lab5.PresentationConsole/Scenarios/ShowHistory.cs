using Lab5.ApplicationATM.Ports;
using Spectre.Console;

namespace Lab5.PresentationConsole.Scenarios;

public class ShowHistory(IAccountService accountService) : Scenario(accountService)
{
    public override string ScenarioName() => "Show History";

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

        ICollection<string> history = GetAccountService().ShowTransactionHistory(username);
        AnsiConsole.MarkupLine("[bold white]transaction    amount    date[/]" + '\n');
        foreach (string transaction in history)
        {
            AnsiConsole.WriteLine(transaction);
        }
    }
}