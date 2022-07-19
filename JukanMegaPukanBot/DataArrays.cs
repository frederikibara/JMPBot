using System;
using System.Collections.Generic;


namespace JukanMegaPukanBot
{
    class DataArrays
    {
        //public List<string> BotCommands = new List<string>();
        private readonly string[] BotCommands = new string[20];
#pragma warning disable CS0649 // Полю "DataArrays.n" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
        int n;
#pragma warning restore CS0649 // Полю "DataArrays.n" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
       
        public DataArrays()
        {
            BotCommands[0] = "/join";
            BotCommands[2] = "/join";
        }



        public string GetBotCommands()
        {
            BotCommands[0] = "/join";


            // Список игровых команд, для JMP 
            // BotCommands.Add("/join");  // join in game
            //BotCommands.Add("/hit");   // hit the govnoball
            // BotCommands.Add("/out");   // if => аут делает раз в день когото вне игры
            //BotCommands.Add("/show");  // statistic of the game
            // BotCommands.Add("/left");  // left the game

             return BotCommands[n];

            // Список званий и игровых чинов JMP 
            /* BotCommands.Add("Чистюля");         // 1 - 4 
             BotCommands.Add("Воин";            // 6 - 9
             BotCommands.Add("Засранец";        // 10 - 19
             BotCommands.Add("Пукан";           // 20 - 39
             BotCommands[9]  = "Какашка";         // 40 - 69 
             BotCommands[10] = "Дерьмо";          // 70 - 89
             BotCommands[10] = "Конское Дерьмо";  // 100 - 139
             BotCommands[11] = "Обосраный";       // 140 - 169
             BotCommands[11] = "Сраное Дерьмо";   // 170 - 199
             BotCommands[12] = "Король Параши";   // 200+
             return BotCommands[n];
             // Список попаданий в кого либо в JMP (получение профессии)
            /* BotCommands[13] = "Миротворец";        // 1 - 10 
             BotCommands[14] = "Воин";              // 6 - 9
             BotCommands[15] = "Засранец";          // 10 - 19
             BotCommands[16] = "Пукан";             // 20 - 39
             BotCommands[17] = "Какашка";           // 40 - 69 
             BotCommands[18] = "Дерьмо";            // 70 - 89
             BotCommands[19] = "Конское Дерьмо";    // 100 - 139
             BotCommands[20] = "Обосраный";         // 140 - 169
             BotCommands[21] = "Сраное Дерьмо";                  // 170 - 199
             BotCommands[22] = "Гуру";              // 200+*/

        }
    }
}
