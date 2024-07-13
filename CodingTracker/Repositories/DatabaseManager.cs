using Microsoft.Data.Sqlite;
using Dapper;
using System.Configuration;
using Spectre.Console;

// Purpose of class:
// The DatabaseManager class is responsible for managing the SQLite database connection and schema. 
// It retrieves the connection string from the configuration file and provides a method to create the "coding" table if it does not already exist.
internal class DatabaseManager
{
    private readonly string connectionString;
    private readonly string tableName = "coding";

    public DatabaseManager()
    {
        try
        {
            //Retrieve the connection string from the app.config file
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not found or is empty in the configuration file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while retrieving the connection string: {ex.Message}");
            throw;
        }
        
    }

    
    internal void CreateTable()
    {
        try
        {
            //Create table
            using (var connection = new SqliteConnection(connectionString))
            {
                AnsiConsole.Markup("[underline yellow]Opening connection...[/]\n");
                connection.Open();
                AnsiConsole.Markup("[underline green]Connection Opened[/]\n");

                string tableCmd = $@"
                    CREATE TABLE IF NOT EXISTS {tableName} (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DATE TEXT NOT NULL,
                            DURATION TEXT NOT NULL
                    );";

                connection.Execute(tableCmd);
                AnsiConsole.Markup($"[bold green]Table {tableName} created successfully![/]\n");
                AnsiConsole.Markup("[bold green]----------------------------------[/]\n");

            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            Console.WriteLine($"An error occurred while creating the table: {ex.Message}");
            throw;
        }
    }
}