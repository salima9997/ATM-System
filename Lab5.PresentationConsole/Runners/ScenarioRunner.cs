using Lab5.ApplicationATM.Ports;
using Lab5.PresentationConsole.Scenarios;
using Spectre.Console;

namespace Lab5.PresentationConsole.Runners;

public class ScenarioRunner(IAccountService accountService)
{
    private IEnumerable<Scenario> Scenarios { get; } = new List<Scenario>
    {
        new CreateAccount(accountService),
        new ShowBalance(accountService),
        new Replenishment(accountService),
        new Withdraw(accountService),
        new ShowHistory(accountService),
    };

    public void Execute()
    {
        SelectionPrompt<Scenario> selector = new SelectionPrompt<Scenario>()
            .Title("[bold white]Select action[/]")
            .AddChoices(Scenarios)
            .UseConverter(x => x.ScenarioName());
        Scenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }
}