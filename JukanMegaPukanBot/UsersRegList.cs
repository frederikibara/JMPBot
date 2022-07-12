using System;
using System.Collections.Generic;

namespace JukanMegaPukanBot
{
    class UsersRegList 
    {    
       // public string InputUserName { get; set; }

        public List<string> Users = new List<string>();

        public ConnectorToDB conn;

        public void AddUserToList(string user)
        {
            conn = new ConnectorToDB();
            conn.UsersFromDBToObject(user);
            //Users.Add(user);

          /*  if (Users.Contains(user))
            {
                           Console.WriteLine(user + " Уже есть в списке! ");
               return false;

            }

            else
            {
                           Console.WriteLine("В 'БД' и 'List' добавлено имя : " + user);
                           Console.WriteLine("Вcего " + Users.Count + " человек(а) зарегистрировано !");
              return true;
            }*/

        }

    }

}
