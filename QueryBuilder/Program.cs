﻿using Microsoft.Data.Sqlite;
using QueryBuilder;

var file = Directory
    .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
var path = Path.Combine(file, @"Data\", "Lab5.db");
Console.Write("PATH: " + path + "\n");
var connection = new SqliteConnection("Data Source=" + @$"{path}");
var done = false;
while (!done)
    if (File.Exists(path))
    {
        var QB = new Querybuilder.QueryBuilder();
        Console.WriteLine(
            "What would you like to do?\n" +
            "1: create new Database item\n" +
            "2: Read a database row\n" +
            "3: read all entries in a table\n" +
            "4: update an entry\n" +
            "5: delete row in table\n" +
            "6: exit");
        string choice;
        choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                //Create
                QB.Create<Author>();
                break;
            case "2":
                //Read
                Console.WriteLine("enter index number starting at 0");
                try
                {
                    var index = Convert.ToInt32(Console.ReadLine());
                    QB.Read<Author>(index);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not a valid index number");
                    throw;
                }

                break;
            case "3":
                QB.ReadAll<Author>();
                Thread.Sleep(1000);
                break;
            case "4":
                //update
                QB.Update<Author>();
                break;
            case "5":
                //delete
                QB.Delete<Author>();
                break;
            case "6":
                QB.Dispose();
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Please inter a valid Int 1-6");
                break;
        }
    }

    else
    {
        Console.WriteLine("File does not Exist");
    }