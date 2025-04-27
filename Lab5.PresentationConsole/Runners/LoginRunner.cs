using Lab5.ApplicationATM.Ports;
using Lab5.PresentationConsole.Logins;
using Spectre.Console;

namespace Lab5.PresentationConsole.Runners;

public class LoginRunner(IAccountService accountService)
{
    private IEnumerable<Login> Logins { get; } = new List<Login>
    {
        new LoginAdmin(accountService),
        new LoginUser(accountService),
    };

    public void Execute()
    {
        SelectionPrompt<Login> selector = new SelectionPrompt<Login>()
            .Title("[bold white]Select role[/]")
            .AddChoices(Logins)
            .UseConverter(x => x.Name());
        Login login = AnsiConsole.Prompt(selector);
        login.Run();
    }
}