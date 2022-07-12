using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotClient
{
    class ConnecterToBase1
    {
        public SQLiteConnection DataBase;

        //public long chatID { get; set; }
        public string inputUserName { get; set; }

        public List<string> Users = new List<string>();


        public ConnecterToBase1()
        {
            DataBase = new SQLiteConnection(@"Data Source=C:\Users\Fred\source\repos\MyBots\JukanMegaPukanBot\D.db3; version=3;");

        }

        public void InsertToDB(string inputUserName)
        {

            // this.chatID = chatID;
            this.inputUserName = inputUserName;
            try
            {
                DataBase.Open();

                SQLiteCommand regcmd = DataBase.CreateCommand();

                regcmd.CommandText = "INSERT INTO users_reg VALUES (@user)";

                //regcmd.Parameters.AddWithValue("@chatID", chatID);
                regcmd.Parameters.AddWithValue("@user", inputUserName);

                regcmd.ExecuteNonQuery();

                DataBase.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }          
        }

        public void AddUserToList(string user)
        {         
            string inputUserName = Console.ReadLine();
         
            this.inputUserName = inputUserName;

            

            if (Users.Contains(inputUserName))
                    {
                        Console.WriteLine(inputUserName + " Уже есть в списке! ");                      
                    }

                    else
                    {
                        Users.Add(inputUserName);
 
                        Console.WriteLine("В 'БД' и 'List' добавлено имя : " + inputUserName);
                        Console.WriteLine("Вcего " + Users.Count() + " человек(а) зарегистрировано !");

                        InsertToDB(inputUserName);
            }

        }








    }

}

