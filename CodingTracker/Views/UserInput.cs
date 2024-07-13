using Spectre.Console;

internal class UserInput
{
    // This class will show main menu
    // Register user input?
    public void MainMenu()
    {
        var menu = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Welcome, what do you want to do?")
            .PageSize(10)
            .AddChoices(new[]
            {
                "1. Register new coding session",
                "2. View previous coding sessions",
            }));

        switch (menu)
        {
            case "1. Register new coding session":
                AnsiConsole.Markup("[bold]You picked Register new coding session[/]");
                break;

            case "2. View previous coding sessions":
                AnsiConsole.Markup("[bold]You picked View previous coding sessions[/]");
                break;

            default:
                AnsiConsole.Markup("[red]Invalid choice[/]");
                break;
        }
    }
}