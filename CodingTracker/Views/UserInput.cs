using Spectre.Console;

// Purpose of class:
// The UserInput class is responsible for displaying the main menu to the user and handling their 
// input. It uses Spectre.Console to provide a selection prompt for registering a new coding session or viewing 
// previous coding sessions. Based on the user's choice, the class calls upon Controller classes to execute

internal class UserInput
{
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
                AnsiConsole.Markup("You picked Register new coding session");
                Create.InsertRecord();
                break;

            case "2. View previous coding sessions":
                AnsiConsole.Markup("[bold]You picked View previous coding sessions[/]");
                Read.DisplayRecords();
                break;

            default:
                AnsiConsole.Markup("[red]Invalid choice[/]");
                break;
        }
    }
}