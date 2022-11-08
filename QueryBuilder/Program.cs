using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using QueryBuilder;
using Microsoft.Data.Sqlite;


    string file = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
    string path = Path.Combine(file, @"Data\", "Lab5.db");
    Console.Write("PATH: "+ path);
    SqliteConnection connection = new SqliteConnection("Data Source=" + @$"{path}");
    bool done = false;
    while (!done)
    {


        if (File.Exists(path))
        {
            Querybuilder.QueryBuilder test = new Querybuilder.QueryBuilder();
            string choice;
            choice = Console.ReadLine().ToString();
            switch (choice)
            {
                case "1" :
                    //Create
                    test.Create<Author>();
                    break;
                    case "2":
                        //update
                        break;
                        case "3":
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
                            case "4":
                                test.ReadAll<Author>();
                                break;






                                //delete
                    test.Delete<Author>();
                    //Create
                    test.Create<Author>();
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

                    test.Dispose();









            }
        }

        else
            {
                Console.WriteLine("File does not Exist");
            }
        }
    }
    

    
