using System;
using Telegram.Bot;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions.Polling;
using System.Timers;

namespace JukanMegaPukanBot
{
    class Program
    {
        public static string JMP = "PukanTestBOT";
        public static Game game;

        public static int Score = 0;

        public static System.Timers.Timer timer;

        public static ConnectorToDB Connect;

        private static string CurrentUserName;

        private static long CurrentChatId;

        private const string key = "5411041906:AAGby4zeJEePlO72giVzogQo_BkAREuwQHA";

        private static ITelegramBotClient JukanBot { get; set; }

        public static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            var message = update.Message;

            if (update.Type == UpdateType.Message && !string.IsNullOrEmpty(update.Message.Text))
            {
    // ***** РЕГИСТРАЦИЯ *****
                if (update.Message.Text.ToLower() == "/join" || update.Message.Text == "/join@JukanMegaPukanBot")
                {                  
                    CurrentUserName = message.From.FirstName;      
                    CurrentChatId = message.MigrateToChatId.GetValueOrDefault(message.Chat.Id);

                    Connect.UsersFromDBToObject(CurrentUserName);
                    //-1001658574467  
                    if (Connect.IsAddedToDB == true) {

                    await bot.SendTextMessageAsync(CurrentChatId, "Ура! 🔥 " + CurrentUserName + ", тепер ти у всесвіті ПУКАНА!", cancellationToken: cancellationToken);
                                            
                        Connect.InsertToDB(CurrentUserName);
                        //replyToMessageId: update.Message.MessageId, 
                        //Проверка юзеров в листах
                        Connect.CheckUsersInDB();
                        Console.WriteLine("Всего в листе " + ConnectorToDB.Users.Count.ToString() + " игроков");
                        return;                        
                    }
                   else {
                        Connect.UserInGame = true;
                        await bot.SendTextMessageAsync(CurrentChatId, CurrentUserName + " ти вже тут", cancellationToken: cancellationToken);                       
                        return;
                   }                  
                }
    // ***** ЗАПУСК ГОВНА *****
                if (update.Message.Text.ToLower() == "/hit")
                {

                    Random random = new Random();

                    Console.WriteLine(CurrentUserName + " запустил говно"); // проверка, кто из юзеров запустил говно

                    bool UserHittingToday = false;

                    CurrentUserName = message.From.FirstName;
                    CurrentChatId = message.MigrateToChatId.GetValueOrDefault(message.Chat.Id);

                    Connect.UsersFromDBToObject(CurrentUserName);
                    if (Connect.UserInGame == true && UserHittingToday == false)
                    {  //⚠️ ☣️
                        await bot.SendTextMessageAsync(CurrentChatId, "❗ УВАГА ❗", cancellationToken: cancellationToken);
                      //  Score++;

                        Thread.Sleep(2100);

                        for (int i = 0; i < Game.mass.Length; i++)
                        {
                            await bot.SendTextMessageAsync(CurrentChatId, Game.mass[i], cancellationToken: cancellationToken);

                            Thread.Sleep(1100);
                        }

                        //Получение списка активных игроков!!!!
                        foreach (string users in ConnectorToDB.Users) 
                        {
                            Console.WriteLine(users);
                        }
                                        
                        int R = random.Next(ConnectorToDB.Users.Count);

    // ***** СЦЕНАРИЙ *****
                        if (ConnectorToDB.Users[R].ToString().Equals(JMP))   
                        {
                            await bot.SendTextMessageAsync(CurrentChatId, "Нікого не обісрало", cancellationToken: cancellationToken);
                            UserHittingToday = true;
                        }

                        if (ConnectorToDB.Users[R].ToString().Equals(CurrentUserName))
                        {
                            await bot.SendTextMessageAsync(CurrentChatId, "Дідько 🤭 то рикошет у ➖ " + CurrentUserName, cancellationToken: cancellationToken);
                            UserHittingToday = true;
                        }

                        else if (!ConnectorToDB.Users[R].ToString().Equals(CurrentUserName) && !ConnectorToDB.Users[R].ToString().Equals(JMP))   
                        {
                            await bot.SendTextMessageAsync(CurrentChatId, "Бум 😱 ГІВНО влучило 💩 у ➖ " + ConnectorToDB.Users[R].ToString(), cancellationToken: cancellationToken);                  
                            UserHittingToday = true;
                        }
                        return; 
                    }
                    else
                    {
                        CurrentUserName = message.From.FirstName;
                        CurrentChatId = message.MigrateToChatId.GetValueOrDefault(message.Chat.Id);
                        await bot.SendTextMessageAsync(CurrentChatId, "Зареєструйтесь /join ", cancellationToken: cancellationToken);
                        return;
                    }
                }           
            }
        }

#pragma warning disable CS1998 // В данном асинхронном методе отсутствуют операторы await, поэтому метод будет выполняться синхронно. Воспользуйтесь оператором await для ожидания неблокирующих вызовов API или оператором await Task.Run(...) для выполнения связанных с ЦП заданий в фоновом потоке.
        public static async Task HandleUErrorAsync(ITelegramBotClient bot, Exception ex, CancellationToken cancellationToken)
#pragma warning restore CS1998 // В данном асинхронном методе отсутствуют операторы await, поэтому метод будет выполняться синхронно. Воспользуйтесь оператором await для ожидания неблокирующих вызовов API или оператором await Task.Run(...) для выполнения связанных с ЦП заданий в фоновом потоке.
        {
            Console.WriteLine("1" + ex);
        }

        public static void Main(string[] args)  //{ Timeout = TimeSpan.FromSeconds(2)}
        {
            
             JukanBot = new TelegramBotClient(key);          
             Connect = new ConnectorToDB();

            Console.WriteLine("бот работает " + JukanBot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationT = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
             AllowedUpdates = {},
            };

            timer = new System.Timers.Timer();
            timer.Interval = 2000;

            //Console.WriteLine(date.GetDateTimeFormats());
            Connect.CheckUsersInDB();
            Console.WriteLine("Всего в листе " + ConnectorToDB.Users.Count.ToString() + " игроков");

            JukanBot.StartReceiving(HandleUpdateAsync, HandleUErrorAsync, receiverOptions, cancellationT);
            Console.ReadLine();                        
        }
    }
}



