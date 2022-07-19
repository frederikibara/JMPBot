using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace JukanMegaPukanBot
{
    class ConnectorToDB
    {
        public SQLiteConnection DataBase;
        public static List<string> Users = new List<string>();

        public static List<User> players;

        public bool IsAddedToDB;
        public bool UserInGame;

#pragma warning restore CS0649 // Полю "ConnectorToDB.UserInGame" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию false.

        public ConnectorToDB()
        {
            DataBase = new SQLiteConnection(@"Data Source=C:\Users\Fred\source\repos\MyBots\JukanMegaPukanBot\D.db3; version=3;");          
        }
        public bool InsertToDB(string inputUserName)
        {           
            try
            {
                DataBase.Open();

                SQLiteCommand regcmd = DataBase.CreateCommand();

                regcmd.CommandText = "INSERT INTO users_reg VALUES (@user)";              
            
                regcmd.Parameters.AddWithValue("@user", inputUserName);
               // regcmd.Parameters.AddWithValue("@win", win);

               // players.Add(new User(inputUserName, 0));

                regcmd.ExecuteNonQuery();
                DataBase.Close();
                UserInGame = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

           return UserInGame;
        }

        public void UsersFromDBToObject(string inputUserName)
        {
            try
            {
                DataBase.Open();

                SQLiteCommand regcmd = DataBase.CreateCommand();
                // WHERE user='{inputUserName}'
                regcmd.CommandText = "SELECT * FROM users_reg";

                SQLiteDataReader Reader = regcmd.ExecuteReader();
                Reader.Read();

                if (Reader.HasRows)
                {
                    IsAddedToDB = true;  // Пользователь уже в базе данных (false - добавлен в базу)
                    UserInGame = false;  // Пользователь не в игре (true - в игре)

                    while (Reader.Read() && IsAddedToDB) {

                        for (int i = 0; i < Reader.FieldCount; i++)
                        {                                                       
                            if (!Reader.GetString(i).Contains(inputUserName) )
                        {                                                   
                                //UserInGame = true;
                                Console.WriteLine("Данные " + Reader.GetString(i));
                                
                            }
                            if (Reader.GetString(i).Contains(inputUserName))
                        {
                                IsAddedToDB = false;
                                UserInGame = true;

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

        public List<string> CheckUsersInDB()
        {
            Console.WriteLine("Проверяем всех, кто уже в игре");

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
                    IsAddedToDB = true;  // Пользователь уже в базе данных (false - добавлен в базу)
                    UserInGame = false;  // Пользователь не в игре (true - в игре)

                   while (Reader.Read() && IsAddedToDB)
                   {
                       for (int i = 0; i < Reader.FieldCount; i++)
                        {
                            Users.Add(Reader.GetString(i));
                            Console.WriteLine("В лист добавлен " + Reader.GetString(i));
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

            return Users;
        }

        public void LeftTheGame(string inputUserName)
        {
            try
            {
                DataBase.Open();
                SQLiteCommand regcmd = DataBase.CreateCommand();
                regcmd.CommandText = $"DELETE user FROM users_reg WHERE user='{inputUserName}'";

                regcmd.ExecuteNonQuery();

                DataBase.Close();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NO Connection to db" + ex);
            }
        }
    }
}
