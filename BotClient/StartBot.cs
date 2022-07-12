using System;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.Threading;
using System.Data.SQLite;
using System.Collections.Generic;

namespace BotClient
{
    class StartBot
    {

        /*  private class BotUpdate
          {
              public string text { get; set; }
              public long id { get; set; }
              public string username { get; set; }
              public string nickname { get; set; }

          }



          private static string Token { get; set; } = "5555218780:AAHgu1OpSQaR8qxlk5uwBEXZDECv58VONi4";
          private static ITelegramBotClient BOT;

          private static string join = "/join";


          public static SQLiteConnection DataBase;


          static void Main(string[] args)
          {

              BOT = new TelegramBotClient(Token);

              var receiverOptions = new ReceiverOptions
              {


              };


              BOT.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);



              Console.ReadLine();



          }

          private static async Task UpdateHandler(ITelegramBotClient myBot, Update update, CancellationToken arg3)
          {
              var botUpdate = new BotUpdate
              {
                  text = update.Message.Text,
                  id = update.Message.Chat.Id,
                  username = update.Message.Chat.Username,
                  nickname = update.Message.Chat.FirstName,  


              };

              var message = update.Message;

              // Telegram.Bot.Requests.GetChatRequest(botUpdate.GetType().FullName)
              // botUpdate.GetType().FullName)     && update.Message.NewChatMembers != null    update.Type == UpdateType.Message  

              if (update.Type == UpdateType.Message && update.Message.Text != null)

              {
                  if (update.Message.Text == join )
                  {
                      UserRegistration2(botUpdate.id);

                      await BOT.SendTextMessageAsync(update.Message.Chat.Id, "Ура! 🔥 " + botUpdate.nickname + ", теперь ты во вселенной ПУКАНА!");
                  }
                  else
                  {
                      await BOT.SendTextMessageAsync(update.Message.Chat, "Войдите с помощью /join");
                  }



                  //ПРОВЕРКА БОТА
                  Console.WriteLine("BOT INFO : " + botUpdate.GetType().FullName.ToString());


                  Console.WriteLine("CHAT INFO : " + update.Message.MessageId);
                  Console.WriteLine("CHAT INFO : " + update.Message.Date);
                  Console.WriteLine("CHAT INFO : " + update.Message.Chat);
                  Console.WriteLine("CHAT INFO : " + update.Message.AuthorSignature);


              }
          }

          private static void JsonConverter(Type type)
          {
              throw new NotImplementedException();
          }

          private static async Task ErrorHandler(ITelegramBotClient arg1, Exception ex, CancellationToken arg3)
          {

          }

          public static void UserRegistration(long ChatID, string UserName)
          {

              try { 
              DataBase = new SQLiteConnection("Data Source = DB.db;");

              DataBase.Open();

                  SQLiteCommand regcmd = DataBase.CreateCommand();
                  regcmd.CommandText = "INSERT INTO RegUsers VALUES(@ChatID, @UserName)";

                  regcmd.Parameters.AddWithValue("@ChatID", ChatID);
                  regcmd.Parameters.AddWithValue("@UserName", UserName);

                  regcmd.ExecuteNonQuery();

                  DataBase.Close();
              }
              catch (Exception ex)
              {
                  Console.WriteLine("NO Connection to db" + ex);
              }
          }

          public static void UserRegistration2(long ChatID)
          {

              try
              {
                  DataBase = new SQLiteConnection("Data Source = DB.db;");

                  DataBase.Open();

                  SQLiteCommand regcmd = DataBase.CreateCommand();
                  regcmd.CommandText = "INSERT INTO RegUsers VALUES(@ChatID)";

                  regcmd.Parameters.AddWithValue("@ChatID", ChatID);


                  regcmd.ExecuteNonQuery();

                  DataBase.Close();
              }
              catch (Exception ex)
              {
                  Console.WriteLine("NO Connection to db" + ex);
              }
          }*/
        static string input;
        
        public static void Main(string [] args)
        {
            ConnecterToBase1 connect = new ConnecterToBase1();

            while (true) {

                
                connect.AddUserToList(input);
                
               // connect.InsertToDB(input);

           // Console.WriteLine("Информация внесена в базу данных ");
           // Console.ReadLine();
            }

        }

    }



}
