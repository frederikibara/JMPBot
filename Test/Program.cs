using System;
using System.Data.SQLite;

namespace Test
{
    class Program
    {
        public static User user;

        public static SQLiteConnection DataBase = new SQLiteConnection(@"Data Source=C:\Users\Fred\source\repos\MyBots\JukanMegaPukanBot\D.db3; version=3;");
     
        public static string inputUserName { get; set; }
        public static string GettingUser { get; set; }


        static void Main(string[] args)
        {
              Console.WriteLine(user.name);
         
                try
                {
                    DataBase.Open();

                    SQLiteCommand regcmd = DataBase.CreateCommand();

                    regcmd.CommandText = "INSERT INTO users_reg VALUES (@user)";
                    regcmd.CommandText = "INSERT INTO users_reg VALUES (@status)";
                    regcmd.CommandText = "INSERT INTO users_reg VALUES (@score)";

                regcmd.Parameters.AddWithValue("@user", inputUserName, 
                                               "@status", inputUserName,
                                               "@score", inputUserName);

                    regcmd.ExecuteNonQuery();
                    DataBase.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            /*while (true)
            {
                inputUserName = Console.ReadLine();


                try
                {
                    DataBase.Open();

                    SQLiteCommand regcmd = DataBase.CreateCommand();

                    regcmd.CommandText = "INSERT INTO users_reg VALUES (@user)";

                    regcmd.Parameters.AddWithValue("@user", inputUserName);

                    regcmd.ExecuteNonQuery();

                    DataBase.Close();

                    UsersFromDBToObject(inputUserName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

        }*/

                /*  public static string UsersFromDBToObject(string inputUserName)
                  {

                      try
                      {
                          DataBase.Open();

                          SQLiteCommand regcmd = DataBase.CreateCommand();

                        //  regcmd.CommandText = $"SELECT user FROM users_reg WHERE user = {inputUserName}";
                          regcmd.CommandText = $"UPDATE user FROM users_reg WHERE user = {inputUserName}";
                          regcmd.Prepare();
                         int GettingUser = regcmd.ExecuteNonQuery();
                          //  inputUserName = regcmd.ExecuteScalar().ToString();

                          /* if (value != null)
                           {
                               inputUserName = regcmd.ExecuteScalar().ToString();
                           }

                          // GettingUser = regcmd.ExecuteScalar().ToString();

                         // regcmd.CommandText = $"SELECT user FROM users_reg WHERE user = {inputUserName}";
                        //  inputUserName = regcmd.ExecuteScalar().ToString();
                          Console.WriteLine("Данные из таблицы : " + GettingUser.ToString());


                          DataBase.Close();
                      }
                      catch (Exception ex)
                      {
                          Console.WriteLine("NO Connection to db" + ex);
                      }
                      return GettingUser;
                  }
          */
            }

