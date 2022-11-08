using System;
using System.Data.SqlClient;
using System.Reflection;
using QueryBuilder;
using Microsoft.Data.Sqlite;


    string file = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
    string path = Path.Combine(file, @"Data\", "Lab5.db");
    Console.Write("PATH: "+ path);
    SqliteConnection connection = new SqliteConnection("Data Source=" + @$"{path}");
    if (File.Exists(path))
    {
        Querybuilder.QueryBuilder test = new Querybuilder.QueryBuilder(path);
        
        //Create
        
        //Read
        test.ReadAll<Author>(connection);
        test.Dispose();
        
        
        
        
        
        
        
        
        
    }
    else
    {
        Console.WriteLine("File does not Exist");
    }
    

    
