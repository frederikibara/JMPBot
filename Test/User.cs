using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class User 
    {
        public string name;
        public string status;
        public int score;

      /*  public User(string name, string status, int score)
        {
            this.name = name;
            this.status = status;
            this.score = score;
        }*/

        public User SetName(string name)
        {
            this.name = name;
            return this;

        }


    }
}
