using System.Data;
using System.Data.SqlClient;

namespace QueryBuilder;

// We need this so ADO.NET can interact w SQLite
using Microsoft.Data.Sqlite;

public class Querybuilder
{
    public class QueryBuilder : IDisposable
    {
        // db connection referenced by the 'connection' field

        private SqliteConnection connection = new SqliteConnection(
            "Data Source=" +
            @$"{Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString(), @"Data\", "Lab5.db")}");


        /// <summary>
        /// Constructor will set up our connection to a given SQLite database file and open it.
        /// </summary>
        /// <param name="databaseLocation">File path to a .db file</param>
        public QueryBuilder()
        {
            connection.Open();
        }
        
        //No idea how youre suppose to return a generic list????? 
        public void ReadAll<T>() 
        {
            Type type = typeof(T);
            String[] stringSplitter = type.ToString().Split(".");
            
            connection.Open();
            SqliteCommand cmd = new SqliteCommand($"Select * from {stringSplitter[1]}", connection);
            var coloumnNames = cmd.ExecuteReader();
            List<string> coloumnNameList = new List<string>();
            for (var i = 0; i < coloumnNames.FieldCount; i++)
            {
                coloumnNameList.Add(coloumnNames.GetName(i));
            }

            coloumnNames.Close();
            SqliteDataReader reader = cmd.ExecuteReader();
            for (int i = 0; i < coloumnNameList.Count; i++)
            {
                Console.Write($"{coloumnNameList[i]}    ");
            }


            while (reader.Read())
            {
                Console.WriteLine();
                if (stringSplitter[1] == "Author")
                {
                    List<Author> objectList = new List<Author>();
                    objectList.Add(new Author($"{reader.GetString(0)}", $"{reader.GetString(1)}",
                        $"{reader.GetString(2)}"));
                    Console.WriteLine(objectList[^1]);
                 
                }
            }
            
        } 
        //not sure how you're supposed to return a generic object????
        public void Read<T>(int index)
        {
            Type type = typeof(T);
            String[] stringSplitter = type.ToString().Split(".");
            connection.Open();
            SqliteCommand cmd = new SqliteCommand($"Select * from {stringSplitter[1]}", connection);
            var coloumnNames = cmd.ExecuteReader();
            List<string> coloumnNameList = new List<string>();
            for (var i = 0; i < coloumnNames.FieldCount; i++)
            {
                coloumnNameList.Add(coloumnNames.GetName(i));
            }

            coloumnNames.Close();
            SqliteDataReader reader = cmd.ExecuteReader();
            for (int i = 0; i < coloumnNameList.Count; i++)
            {
                Console.Write($"{coloumnNameList[i]}    ");
            }


            while (reader.Read())
            {
                Console.WriteLine();
                if (stringSplitter[1] == "Author")
                {
                    List<Author> objectList = new List<Author>();
                    objectList.Add(new Author($"{reader.GetString(0)}", $"{reader.GetString(1)}",
                        $"{reader.GetString(2)}"));
                    Console.WriteLine(objectList[index]);
                    break;
                }
            
            }

            
        }

        public void Create<T>()
        {
            Type type = typeof(T);
            String[] stringSplitter = type.ToString().Split(".");
            connection.Open();
            if (stringSplitter[1] == "author") ;
            {
                Console.WriteLine("\nTable: Author");
                //this is my weird way to make sure the string is a number, could have done it a different way but lazy
                Console.WriteLine("ID: ");
                string id = Convert.ToString(Convert.ToInt32(Console.ReadLine().ToString()));
                Console.WriteLine("firstName:");
                string firstName = Console.ReadLine();
                Console.WriteLine("SurName");
                string surName = Console.ReadLine();
                
                SqliteCommand cmd = new SqliteCommand($"Insert into {stringSplitter[1]} (id, firstname, surname) VALUES ('{id}','{firstName}','{surName}')", connection);
                cmd.ExecuteNonQuery();
            }
            
            
        }

        public void Delete<T>()
        {
            Type type = typeof(T);
            String[] stringSplitter = type.ToString().Split(".");
            Console.WriteLine(type.ToString().Split("."));
            connection.Open();
          
         
            Console.WriteLine($"Enter the ID of the the item you want to delete: ");
            string deleteID = Convert.ToString(Convert.ToInt32(Console.ReadLine().ToString()));
            SqliteCommand cmd = new SqliteCommand($"Delete from {stringSplitter[1]} where ID = {deleteID}", connection);
            cmd.ExecuteNonQuery();
        }


        /// <summary>
        /// By implementing IDisposable, we have the capability to 
        /// use a QueryBuilder object in a 'using' statement in our
        /// driver; when that using statement is complete, our Sqlite
        /// connection will be closed automatically
        /// </summary>
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}

public interface IClassModel
{
    string id { get; set; }
}

public class T : IClassModel
{
    public string id
    { get; set;}
}

public class Author : T
{
    public string id { get; set; }
    private string FirstName { get; set; }
    private string SurName { get; set; }

    internal Author(string id, string firstname, string surName)
    {
        this.id = id;
        this.FirstName = firstname;
        this.SurName = surName;
    }

    public override string ToString()
    {
        return $"{id} {FirstName} {SurName}";
    }
    

    
}