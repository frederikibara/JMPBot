using System;
using System.Data.SQLite;

namespace Test
{
    class Program
    {
        public static SQLiteConnection DataBase = new SQLiteConnection(@"Data Source=C:\Users\Fred\source\repos\MyBots\JukanMegaPukanBot\D.db3; version=3;");
     
        public static string InputUserName { get; set; }
        public static string GettingUser { get; set; }


        static void Main(string[] args)
        {
              Console.WriteLine(InputUserName);
         
                try
                {
                    DataBase.Open();

                    SQLiteCommand regcmd = DataBase.CreateCommand();

                    regcmd.CommandText = "INSERT INTO users_reg VALUES (@user)";
                    regcmd.CommandText = "INSERT INTO users_reg VALUES (@status)";
                    regcmd.CommandText = "INSERT INTO users_reg VALUES (@score)";

                    regcmd.Parameters.AddWithValue("@user", InputUserName);

                    regcmd.ExecuteNonQuery();
                    DataBase.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
        }
    }
}

