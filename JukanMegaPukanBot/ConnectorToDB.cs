using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace JukanMegaPukanBot
{
    class ConnectorToDB
    {
        public SQLiteConnection DataBase;
        
        public bool IsNotAddedToDB = true;

        public bool UserInGame;

        public ConnectorToDB()
        {
            DataBase = new SQLiteConnection(@"Data Source=C:\Users\Fred\source\repos\MyBots\JukanMegaPukanBot\D.db3; version=3;");
        }
        public void InsertToDB(string inputUserName)
        {           
            try
            {
                DataBase.Open();

                SQLiteCommand regcmd = DataBase.CreateCommand();

                regcmd.CommandText = "INSERT INTO users_reg VALUES (@user)";              
            
                regcmd.Parameters.AddWithValue("@user", inputUserName);

                regcmd.ExecuteNonQuery();
                DataBase.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void UsersFromDBToObject(string inputUserName)
        {
            try
            {
                DataBase.Open();

                SQLiteCommand regcmd = DataBase.CreateCommand();
                // WHERE user='{inputUserName}'
                regcmd.CommandText = "SELECT user FROM users_reg";

                SQLiteDataReader Reader = regcmd.ExecuteReader();
                Reader.Read();

                if (Reader.HasRows)
                {   
                    while (Reader.Read() && IsNotAddedToDB) {

                        for (int i = 0; i < Reader.FieldCount; i++)
                        {                                                       
                            if (!Reader.GetString(i).Contains(inputUserName) )
                        {                              
                                IsNotAddedToDB = true;
                                //UserInGame = true;
                                Console.WriteLine("Итерация " + i + " данные " + Reader.GetString(i));                            
                            }
                            if (Reader.GetString(i).Contains(inputUserName))
                        {
                                IsNotAddedToDB = false;
                                Console.WriteLine(inputUserName + " уже есть в базе");
                                break;
                            }                                            
                        }                           
                    }
                }
                Reader.Close();
                DataBase.Close();     
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NO Connection to db" + ex);
            }
        }

        public void LeftTheGame(string inputUserName)
        {
            try
            {
                DataBase.Open();
                SQLiteCommand regcmd = DataBase.CreateCommand();
                // WHERE user='{inputUserName}'
                regcmd.CommandText = $"DELETE user FROM users_reg WHERE user='{inputUserName}'";

                regcmd.ExecuteNonQuery();
               // DataBase.Close();

                /* SQLiteDataReader Reader = regcmd.ExecuteReader();
                  Reader.Read();


                  if (Reader.HasRows)
                  {
                      while (Reader.Read())
                      {

                          for (int i = 0; i < Reader.FieldCount; i++)
                          {
                              if (!Reader.GetString(i).Contains(inputUserName))
                              {
                                  IsNotAddedToDB = true;
                                  //UserInGame = true;
                                  Console.WriteLine("Итерация " + i + " данные " + Reader.GetString(i));
                              }
                              else if (Reader.GetString(i).Contains(inputUserName))
                              {
                                  IsNotAddedToDB = false;
                                  Console.WriteLine(inputUserName + " уже есть в базе");
                                  break;
                              }
                          }
                      }
                  }*/
               // Reader.Close();
                DataBase.Close();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NO Connection to db" + ex);
            }

        }

        }
}
