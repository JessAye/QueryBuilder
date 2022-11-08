using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using QueryBuilder;
using Microsoft.Data.Sqlite;


string file = Directory
    .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
string path = Path.Combine(file, @"Data\", "Lab5.db");
Console.Write("PATH: " + path);
SqliteConnection connection = new SqliteConnection("Data Source=" + @$"{path}");
bool done = false;
while (!done)
{
    if (File.Exists(path))
    {
        Querybuilder.QueryBuilder test = new Querybuilder.QueryBuilder();
        Console.WriteLine("What would you like to do?\n1: create new Database item\n2: Read a database row\n3: read all entries in a table\n4: update an entry\n5: delete row in table\n6: exit");
        string choice;
        choice = Console.ReadLine().ToString();
        switch (choice)
        {
            case "1":
                //Create
                test.Create<Author>();
                break;
            case "2":
                //Read
                Console.WriteLine($"enter index number starting at 0");
                try
                {
                    int index = Convert.ToInt32(Console.ReadLine());
                    test.Read<Author>(index);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not a valid index number");
                    throw;
                }

                break;
            case "3":
                test.ReadAll<Author>();
                break;
            case "4":
                //update
                test.Update<Author>();
                break;
            case "5":
                //delete
                test.Delete<Author>();
                break;
            case "6":
                System.Environment.Exit(1);
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
}