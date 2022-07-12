using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukanMegaPukanBot
{
    class User
    {
        private long Id;
        private string FirstName;
        private bool InGame;

        private int Score;
        private int LoserCount;
        private int WinCount;
        private string Status;


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

        public User(string FirstName)
        {          
            this.FirstName = FirstName;            
        }



    }
}
