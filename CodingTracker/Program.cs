﻿using Spectre.Console;
using System;
using System.Configuration;
using System.Collections.Specialized;



DatabaseManager databaseManager = new();
UserInput userInput = new();

databaseManager.CreateTable();
userInput.MainMenu();



//AnsiConsole.Markup("[underline red]Hello[/] World!");

//Classes:
// UserInput
//Validation
//CodingController
//Database Strings?
//Config file with database path and connection strings
//CodingSession = properties of the coding session: id, startime, endtime duration

//must haves:
//store date and time
//User should not input the duration of the session - CalculateDuration.cs should do the math
//Input start and end times manually

//technologies
//Spectre.Console to show the data
//Dapper ORM for data access

//Whatever this means
//When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.

//Steps:
//1. Config file
//2. Model
//3. Database/table creation
//4. Crud controller
//5. TableVisualisationEngine (showing the output)
//6. Validation of data



