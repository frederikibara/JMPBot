using System;
using System.Collections.Generic;

namespace JukanMegaPukanBot
{
    class User
    {
#pragma warning disable CS0169 // Поле "User.Id" никогда не используется.
        private long Id;
#pragma warning restore CS0169 // Поле "User.Id" никогда не используется.
        public string FirstName;
        private bool InGame;

        public int Score;

#pragma warning disable CS0169 // Поле "User.LoserCount" никогда не используется.
        public int Lose;
#pragma warning restore CS0169 // Поле "User.LoserCount" никогда не используется.
#pragma warning disable CS0169 // Поле "User.WinCount" никогда не используется.
        public int Win;
#pragma warning restore CS0169 // Поле "User.WinCount" никогда не используется.
        public string Status;


      /*  public User(long Id, bool InGame, string FirstName, int Score, int LoserCount, int WinCount, string Status)
        {

        }

        public User(bool InGame, string FirstName, int Score, int WinCount, string Status)
        {

        }
      */
        public User(bool InGame, string FirstName, int Score, string Status)
        {
            this.InGame = InGame;
            this.FirstName = FirstName;
            this.Score = Score;
            this.Status = Status;
        }

        public User(string FirstName, int Win, int Lose, string Status, int Score)
        {          
            this.FirstName = FirstName;
            this.Score = Score;
            this.Win = Win;
            this.Lose = Lose;
            this.Status = Status;
            this.Score = Score;
        }

        public User(string FirstName, int Win)
        {
            this.FirstName = FirstName;
            this.Win = Win;
            
        }



    }
}
