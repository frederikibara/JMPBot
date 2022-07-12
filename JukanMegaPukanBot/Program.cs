using System;
using Telegram.Bot;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions.Polling;

namespace JukanMegaPukanBot
{
    class Program
    {
        public static ConnectorToDB Connect;

        private static string UserWhoInputInChat;

        static UsersRegList ListOfRegUsers = new UsersRegList();

        private const string key = "5411041906:AAGby4zeJEePlO72giVzogQo_BkAREuwQHA";

        private static ITelegramBotClient JukanBot { get; set; }

        private static DataArrays DataArrays;

        public static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            var message = update.Message;

            if (update.Type == UpdateType.Message && !string.IsNullOrEmpty(update.Message.Text))
            {


                /*if (message.Text == null)
                {
                    return;
                }*/
                

                if (update.Message.Text.ToLower() == "/join")
                {
                    //Connect.IsNotAddedToDB = false;

                    UserWhoInputInChat = message.From.FirstName;                  
                    Connect.UsersFromDBToObject(UserWhoInputInChat);
                   
                    if (Connect.IsNotAddedToDB == true) {

                    await bot.SendTextMessageAsync(message.MigrateToChatId.GetValueOrDefault(-1001658574467), "Ура! 🔥 " + UserWhoInputInChat + ", теперь ты во вселенной ПУКАНА!", cancellationToken: cancellationToken);
                     
                        
                        Connect.InsertToDB(UserWhoInputInChat);
                       // ListOfRegUsers.AddUserToList(UserWhoInputInChat);
                        return;                        
                    }
                   else { 
                     await bot.SendTextMessageAsync(message.MigrateToChatId.GetValueOrDefault(-1001658574467), UserWhoInputInChat + " Ты уже в игре", cancellationToken: cancellationToken);
                     return;
                   }
                }

                /*if (update.Message.Text.ToLower() == DataArrays.BotCommands[4])
                {
                    Connect.LeftTheGame(UserWhoInputInChat);

                 /*   if (Connect.IsNotAddedToDB == true)
                    {
                    await bot.SendTextMessageAsync(message.MigrateToChatId.GetValueOrDefault(-1001658574467), "Ура! 🔥 " + UserWhoInputInChat + ", теперь ты во вселенной ПУКАНА!", cancellationToken: cancellationToken);

                       // Connect.InsertToDB(UserWhoInputInChat);
                        
                        return;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(message.MigrateToChatId.GetValueOrDefault(-1001658574467), UserWhoInputInChat + " Ты уже зарегистророван", cancellationToken: cancellationToken);
                        return;
                    }



                }*/

            }
        }

        public static async Task HandleUErrorAsync(ITelegramBotClient bot, Exception ex, CancellationToken cancellationToken)
        {
            Console.WriteLine("");
        }

        public static void Main(string[] args)
        {
             JukanBot = new TelegramBotClient(key) { Timeout = TimeSpan.FromSeconds(10)};

             DataArrays = new DataArrays();           
             Connect = new ConnectorToDB();

            Console.WriteLine("бот работает " + JukanBot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationT = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
             AllowedUpdates = {},
            };

            JukanBot.StartReceiving(HandleUpdateAsync, HandleUErrorAsync, receiverOptions, cancellationT);
            Console.ReadLine();                        
        }
    }
}



